using System.Collections.Generic;
using System.Linq;

namespace UC.Models.ViewModels.ListViewModels
{
    public class VMListChamada
    {
        #region PROPERTIES
        public List<VMChamada> chamadas { get; set; }
        public long? aulaUID { get; set; }
        public long? alunoUID { get; set; }
        #endregion

        #region CONTRUCTORS
        public VMListChamada()
        {

        }

        public VMListChamada(Aula aula)
        {
            this.aulaUID = aula.aulaUID;

            this.chamadas = new List<VMChamada>();

            if (aula.Chamadas != null)
            {
                foreach (var cadaChamada in aula.Chamadas.Where(x => x.ativa).ToList())
                {
                    this.chamadas.Add(new VMChamada(cadaChamada));
                }
            }
        }

        public VMListChamada(Aluno aluno)
        {
            this.alunoUID = aluno.alunoUID;

            this.chamadas = new List<VMChamada>();

            if (aluno.Chamadas != null)
            {
                foreach (var cadaChamada in aluno.Chamadas.Where(x => x.ativa).ToList())
                {
                    this.chamadas.Add(new VMChamada(cadaChamada));
                }
            }
        }
        #endregion
    }
}