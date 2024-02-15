using System;
using System.Linq;
using System.Web.Mvc;
using UC.Models.Enumerators;
using UC.Models.UCEntityHelpers.Interfaces;
using UC.Models.ViewModels.FormViewModels;
using UC.Utility;

namespace UC.Models.UCEntityHelpers
{
    public class CicloHabitoHelper : BaseHelper, ICicloHabitoHelper
    {
        public CicloHabitoHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        public DiaSemanaHabito ObterDiaSemanal(int diaSemanal, Habito habito)
        {
            var diaEncontrado = habito.DiasSemanaHabito.FirstOrDefault(x => x.DiaSemana == diaSemanal && x.Ativo);

            if(diaEncontrado != null)
            {
                return diaEncontrado;
            }

            diaEncontrado = new DiaSemanaHabito
            {
                diaSemanaHabitoUID = 0,
                habitoUID = habito.habitoUID,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DiaSemana = diaSemanal,
                Ordem = habito.DiasSemanaHabito.Count,
                Finalizado = false
            };

            idbucContext.DiasSemanaHabito.Add(diaEncontrado);

            idbucContext.SaveChanges();

            return diaEncontrado;
        }
        public CicloHabito AdicionarCiclo(int tipoCiclo, Habito habito)
        {
            var novoCiclo = new CicloHabito
            {
                cicloHabitoUID = 0,
                habitoUID = habito.habitoUID,
                finalizado = false,
                ativo = true,
                TipoCiclo = tipoCiclo,
                DataCriacao= DateTime.Now,
                MesAno = (int?)null,
                DiaMes = (int?)null
            };

            idbucContext.CiclosHabito.Add(novoCiclo);

            idbucContext.SaveChanges();

            return novoCiclo;
        }
        public HorarioHabito AdicionarHorario(CicloHabito cicloHabito, long? diaSemanaHabitoUID, TimeSpan horarioInicio, TimeSpan horarioTermino)
        {
            var novoHorarioHabito = new HorarioHabito
            {
                horarioHabitoUID = 0,
                Ativo = true,
                DataCriacao = DateTime.Now,
                Finalizado = false,
                cicloHabitoUID = cicloHabito.cicloHabitoUID,
                diaSemanaHabitoUID = diaSemanaHabitoUID,
                HorarioInicio = horarioInicio,
                HorarioTermino = horarioTermino
            };

            idbucContext.HorariosHabito.Add(novoHorarioHabito);

            idbucContext.SaveChanges();

            return novoHorarioHabito;
        }

        public CicloHabito AtualizarCicloHabito(VMFormCicloHabito form, out UserMessage message)
        {
            try
            {
                CicloHabito cicloHabito;
                DiaSemanaHabito diaSemanal = null;
                HorarioHabito horarioHabito;

                var habito = idbucContext.Habitos.Find(form.habitoUID);

                if (!unityOfHelpers.Metas.PossoAlterar(habito.Meta, out message))
                {
                    throw new Exception(message.message);
                }

                cicloHabito = form.cicloHabitoUID > 0 
                    ? habito.CiclosHabito.FirstOrDefault(x => x.ativo && x.cicloHabitoUID == form.cicloHabitoUID)
                    : cicloHabito = AdicionarCiclo(form.TipoCiclo, habito);

                if (form.DiaSemanal.HasValue)
                {
                    diaSemanal = ObterDiaSemanal(form.DiaSemanal.Value, habito);
                }

                var diaSemanalHabitoUID = diaSemanal != null ? diaSemanal.diaSemanaHabitoUID : (long?)null;

                horarioHabito = form.horarioHabitoUID > 0
                    ? cicloHabito.HorariosHabito.FirstOrDefault(x => x.Ativo && x.horarioHabitoUID == form.horarioHabitoUID)
                    : AdicionarHorario(cicloHabito, diaSemanalHabitoUID, form.HorarioInicio, form.HorarioTermino);

                switch ((TipoCiclo)form.TipoCiclo)
                {
                    case TipoCiclo.Diario:
                        {
                            horarioHabito.HorarioInicio = form.HorarioInicio;
                            horarioHabito.HorarioTermino = form.HorarioTermino;
                            horarioHabito.diaSemanaHabitoUID = diaSemanalHabitoUID;

                            idbucContext.SaveChanges();
                        }
                        break;
                    default:
                        throw new Exception($"O tipo de ciclo {((TipoCiclo)form.TipoCiclo).ToFriendlyString()} não está disponível.");
                }

                message = new UserMessage("Ciclo Atualizado!");
                return cicloHabito;
            }
            catch(Exception ex)
            {
                message = new UserMessage(ex);
                return null;
            }
        }
    }
}