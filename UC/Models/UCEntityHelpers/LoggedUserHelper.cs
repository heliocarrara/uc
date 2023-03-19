using UC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Models.UCEntityHelpers
{

    public class LoggedUserHelper : BaseHelper, Interfaces.ILoggedUserHelper
    {
        #region PROPERTIES

        public string pessoaUID { get { return SimpleSessionPersister.Id; } }
        //public long servidorUID { get { return SimpleSessionPersister.servidorUID; } }
        //public int proprietarioUID { get { return SimpleSessionPersister.proprietarioUID; } }
        //public int campusUID { get { return SimpleSessionPersister.campusUID; } }
        //public string nomeCampus { get { return SimpleSessionPersister.nomeCampus; } }
        //public string nomeUnidade { get { return SimpleSessionPersister.nomeUnidade; } }

        #endregion

        #region CONSTRUCTORS

        public LoggedUserHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion

        #region SOMA BINARIA TIPO UNIDADE

        /// <summary>
        /// Enumerador dos tipos básicos de unidades para a soma binária.
        /// </summary>
        //private enum tipos_login
        //{
        //    INSTITUTO_ENSINO = 1,
        //    DIRETORIA_INSTITUTO_ENSINO = 2,
        //    DEPARTAMENTO_ENSINO = 4,
        //    COORDENACAO_ENSINO_GRADUACAO = 8,
        //    COORDENACAO_ENSINO_POS_GRADUACAO = 16,
        //    UNIDADE_LOTACIONAL_DOCENTE = 32,
        //    DIRETORIA_ADJUNTA = 64,
        //    SUPERVISÃO_ENSINO_GRADUAÇÃO = 128,
        //    INFORMAL = 256
        //}

        #endregion

        #region INFOS SOBRE A UNIDADE

        /// <summary>
        /// Booleano que indica se o usuário logado é representante de uma unidade do tipo diretoria ou vice-diretoria.
        /// </summary>
        /*public bool sou_diretoria_que_da_parecer_final
        {
            get
            {
                if (SimpleSessionPersister.UserRole == "InstanciaSuperior")
                {
                    var myUnity = unityOfServices.Localizacao.GetUnidade(unityOfHelpers.UsuarioLogado.unidadeUID.Value);

                    return UnidadeEhDiretoria(myUnity);
                }
                else { return false; }
            }
        }

        /// <summary>
        /// Retorna os valores de unidadeUID referentes as unidades no mesmo nível hierárquico da minha.
        /// </summary>
        public long[] unidadeUID_minhas_unidades_irmas
        {
            get
            {
                var myUnity = unityOfServices.Localizacao.GetUnidade(unityOfHelpers.UsuarioLogado.unidadeUID.Value);

                var unidades = unityOfServices.Localizacao.GetUnidadesPorUnidadeSuperior(myUnity.UnidadeSuperiorUID);

                var result = new List<long>();

                foreach (var unidade in unidades.Where(x => x.UnidadeUID != myUnity.UnidadeUID))
                {
                    result.Add(unidade.UnidadeUID);
                }

                return result.ToArray();
            }
        }

        public bool UnidadeEhDiretoria(UnidadeEntity unidade)
        {
            var DIRETORIA_INSTITUTO_ENSINO = (int)tipos_unidade.DIRETORIA_INSTITUTO_ENSINO;

            return (unidade.TipoUnidade & DIRETORIA_INSTITUTO_ENSINO) != 0;
        }

        public bool UnidadeEhDiretoria(long unidadeUID)
        {
            var unidade = unityOfServices.Localizacao.GetUnidade(unidadeUID);

            if (unidade == null)
            {
                throw new Exception("Unidade com o Identificador Único informado não existe: " + unidadeUID);
            }

            return UnidadeEhDiretoria(unidade);
        }

        public bool UnidadeEhInstituto(UnidadeEntity unidade)
        {
            var INSTITUTO_ENSINO = (int)tipos_unidade.INSTITUTO_ENSINO;

            return (unidade.TipoUnidade & INSTITUTO_ENSINO) != 0;
        }

        public bool UnidadeEhInstituto(long unidadeUID)
        {
            var unidade = unityOfServices.Localizacao.GetUnidade(unidadeUID);

            if (unidade == null)
            {
                throw new Exception("Unidade com o Identificador Único informado não existe: " + unidadeUID);
            }

            return UnidadeEhInstituto(unidade);
        }

        public bool UnidadeDocente(UnidadeEntity unidadeAvaliadora)
        {
            return unidadeAvaliadora.TipoUnidade != 0;
        }

        public bool UnidadeDocente(long unidadeUID)
        {
            var unidade = unityOfServices.Localizacao.GetUnidade(unidadeUID);

            if (unidade == null)
            {
                throw new Exception("Unidade com o Identificador Único informado não existe: " + unidadeUID);
            }

            return UnidadeDocente(unidade);
        }

        public long GetUnidadeAvaliadora(long unidadeUID, out int campusUID, long servidorCoordenador)
        {
            var unidade = unityOfServices.Localizacao.GetUnidade(unidadeUID);

            campusUID = (int)unidade.CampusUID;
            //var unidadeUID_propositora = unidadeUID;
            var unidadeUID_avaliadora = unidadeUID;

            //Se for unidade administrativa e o Coordenador for responsável por ela, quem avalia é a unidade superior
            //Ex: Secretário da STI propõe projeto e quem avalia é a Reitoria
            if (!unityOfHelpers.UsuarioLogado.UnidadeDocente(unidade))
            {
                try
                {
                    var pessoa = unityOfServices.Pessoa.GetPessoaPorServidor(servidorCoordenador);

                    var unidadeQueSouResponsavel = unityOfServices.Localizacao.GetUnidadePorResponsavel(pessoa.pessoaUID);

                    if (unidadeQueSouResponsavel != null && unidadeQueSouResponsavel.UnidadeUID == unidade.UnidadeUID)
                    {
                        //Se existir uma Unidade Superior, a Unidade Superior irá avaliar.
                        //Caso não exista, a própria Unidade Propositora realiza a avaliação.
                        unidadeUID_avaliadora =
                            unidadeQueSouResponsavel.UnidadeSuperiorUID != 0
                            ? unidadeQueSouResponsavel.UnidadeSuperiorUID
                            : unidadeQueSouResponsavel.UnidadeUID;
                    }
                    else
                    {
                        throw new Exception("Pessoa não é responsável pela unidade de proposição");
                    }
                }
                catch
                {
                    unidadeUID_avaliadora = unidadeUID;
                }
            }
            else
            {
                //Senão, quem avalia é a própria unidade do Coordenador
                //Ex: Chefe de Departamento propõe projeto pelo próprio Departamento e ele mesmo avalia
                unidadeUID_avaliadora = unidadeUID;
            }

            return unidadeUID_avaliadora;
        }

        #endregion
    }*/
        #endregion
    }
}