using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UC.Utility;
//using UC.Models.ViewModels.ListViewModels;
using UC.Models.UCEntityHelpers;
using Microsoft.EntityFrameworkCore;
using UC.Models;
using UC.Models.UCEntityHelpers.Interfaces;

namespace UC.Models
{
    public class UnityOfHelpers : IUnityOfHelpers
    {
        #region PUBLIC GET INSTANCES

        public UCDBContext idbucContext { get { return this._db; } }

        public UrlHelper urlHelper { get { return this._url; } }

        #endregion

        #region PRIVATE INSTANCES

        private UrlHelper _url;
        private UCDBContext _db;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Método construtor para a coleção de instâncias.
        /// </summary>
        /// <param name="_url">Url Helper para gerar strings de acesso na aplicação.</param>
        /// <param name="_db">Contexto de conexão do banco de dados.</param>
        /// <param name="_services">Unidade de gerenciamento de acesso aos serviços WCF.</param>
        public UnityOfHelpers(UrlHelper _url, UCDBContext _db)
        {
            this._url = _url;
            this._db = _db;
        }

        #endregion

        #region PUBLIC GET HELPERS

        public ILoggedUserHelper UsuarioLogado { get { if (usuarioLogado == null) { usuarioLogado = new LoggedUserHelper(_url, _db, this); } return UsuarioLogado; } }
        public ISelectListHelper SelectLists { get { if (selectLists == null) { selectLists = new SelectListHelper(_url, _db, this); } return selectLists; } }


        /*public IProjetoHelper Projetos { get { if (projetos == null) { projetos = new ProjetoHelper(_url, _db, _services, this); } return projetos; } }

        public IProgramaHelper Programas { get { if (programas == null) { programas = new ProgramaHelper(_url, _db, _services, this); } return programas; } }

        public IAcaoHelper Acoes { get { if (acoes == null) { acoes = new AcaoHelper(_url, _db, _services, this); } return acoes; } }

        public IAcaoRelatorioHelper AcoesRelatorio { get { if (acoesrelatorio == null) { acoesrelatorio = new AcaoRelatorioHelper(_url, _db, _services, this); } return acoesrelatorio; } }

        public IMembroEquipeHelper MembrosEquipe { get { if (membrosEquipe == null) { membrosEquipe = new MembroEquipeHelper(_url, _db, _services, this); } return membrosEquipe; } }
        public IMembroEquipeRelatorioHelper MembrosEquipeRelatorio { get { if (membrosEquipeRelatorio == null) { membrosEquipeRelatorio = new MembroEquipeRelatorioHelper(_url, _db, _services, this); } return membrosEquipeRelatorio; } }
        public ITurmaHelper Turmas { get { if (turmas == null) { turmas = new TurmaHelper(_url, _db, _services, this); } return turmas; } }
        public ITurmaRelatorioHelper TurmasRelatorio { get { if (turmasRelatorio == null) { turmasRelatorio = new TurmaRelatorioHelper(_url, _db, _services, this); } return turmasRelatorio; } }
        public IProprietarioHelper Proprietarios { get { if (proprietarios == null) { proprietarios = new ProprietarioHelper(_url, _db, _services, this); } return proprietarios; } }

        public IFuncaoMembroHelper FuncoesMembro { get { if (funcoesMembro == null) { funcoesMembro = new FuncaoMembroHelper(_url, _db, _services, this); } return funcoesMembro; } }

        public IFuncaoMembroRelatorioHelper FuncaoMembroRelatorio { get { if (funcaoMembroRelatorio == null) { funcaoMembroRelatorio = new FuncaoMembroRelatorioHelper(_url, _db, _services, this); } return funcaoMembroRelatorio; } }
        public IHomologacaoPropostaHelper Homologacoes { get { if (homologacoes == null) { homologacoes = new HomologacaoPropostaHelper(_url, _db, _services, this); } return homologacoes; } }

        public IPropostaHelper Propostas { get { if (propostas == null) { propostas = new PropostaHelper(_url, _db, _services, this); } return propostas; } }

        public ISelectListHelper SelectLists { get { if (selectLists == null) { selectLists = new SelectListHelper(_url, _db, _services, this); } return selectLists; } }

        public IPublicoAlvoHelper PublicosAlvo { get { if (publicosAlvo == null) { publicosAlvo = new PublicoAlvoHelper(_url, _db, _services, this); } return publicosAlvo; } }
        public IPublicoAlvoAcaoRelatorioHelper PublicosAlvoAcaoRelatorio { get { if (publicosAlvoAcaoRelatorio == null) { publicosAlvoAcaoRelatorio = new PublicoAlvoAcaoRelatorioHelper(_url, _db, _services, this); } return publicosAlvoAcaoRelatorio; } }
        public IProdutoHelper Produtos { get { if (produtos == null) { produtos = new ProdutoHelper(_url, _db, _services, this); } return produtos; } }
        public IProdutoRelatorioHelper ProdutosRelatorio { get { if (produtosRelatorio == null) { produtosRelatorio = new ProdutoRelatorioHelper(_url, _db, _services, this); } return produtosRelatorio; } }
        public IEditalHelper Editais { get { if (editais == null) { editais = new EditalHelper(_url, _db, _services, this); } return editais; } }

        public IRecursoPropostaHelper RecursosProposta { get { if (recursosProposta == null) { recursosProposta = new RecursoPropostaHelper(_url, _db, _services, this); } return recursosProposta; } }

        public IAvaliacaoInstanciaSuperiorHelper AvaliacaoInstanciaSuperior { get { if (avaliacaoInstanciaSuperior == null) { avaliacaoInstanciaSuperior = new AvaliacaoInstanciaSuperiorHelper(_url, _db, _services, this); } return avaliacaoInstanciaSuperior; } }

        public IProtocoloHelper Protocolos { get { if (protocolos == null) { protocolos = new ProtocoloHelper(_url, _db, _services, this); } return protocolos; } }

        public ICargaHorariaHelper CargaHoraria { get { if (cargaHoraria == null) { cargaHoraria = new CargaHorariaHelper(_url, _db, _services, this); } return cargaHoraria; } }

        
        public IAvaliacaoPropostaHelper AvaliacoesProposta { get { if (avaliacoesProposta == null) { avaliacoesProposta = new AvaliacaoPropostaHelper(_url, _db, _services, this); } return avaliacoesProposta; } }

        public IRelatorioProgramaHelper RelatoriosPrograma { get { if (relatoriosPrograma == null) { relatoriosPrograma = new RelatorioProgramaHelper(_url, _db, _services, this); } return relatoriosPrograma; } }

        public IRelatorioProjetoHelper RelatoriosProjeto { get { if (relatoriosProjeto == null) { relatoriosProjeto = new RelatorioProjetoHelper(_url, _db, _services, this); } return relatoriosProjeto; } }

        public IRelatorioMembroEquipeHelper RelatoriosMembroEquipe { get { if (relatoriosMembroEquipe == null) { relatoriosMembroEquipe = new RelatorioMembroEquipeHelper(_url, _db, _services, this); } return relatoriosMembroEquipe; } }
        public IRelatorioMembroEquipeRelatorioHelper RelatoriosMembroEquipeRelatorio { get { if (relatoriosMembroEquipeRelatorio == null) { relatoriosMembroEquipeRelatorio = new RelatorioMembroEquipeRelatorioHelper(_url, _db, _services, this); } return relatoriosMembroEquipeRelatorio; } }
        public IRelatorioAcaoHelper RelatoriosAcao { get { if (relatoriosAcao == null) { relatoriosAcao = new RelatorioAcaoHelper(_url, _db, _services, this); } return relatoriosAcao; } }
        public IRelatorioAcaoRelatorioHelper RelatoriosAcaoRelatorio { get { if (relatoriosAcaoRelatorio == null) { relatoriosAcaoRelatorio = new RelatorioAcaoRelatorioHelper(_url, _db, _services, this); } return relatoriosAcaoRelatorio; } }
        public IRelatorioIdentidadeMembroHelper RelatoriosIdentidade { get { if (relatoriosIdentidade == null) { relatoriosIdentidade = new RelatorioIdentidadeMembroHelper(_url, _db, _services, this); } return relatoriosIdentidade; } }
        public IRelatorioIdentidadeMembroRelatorioHelper RelatoriosIdentidadeRelatorio { get { if (relatorioIdentidadeRelatorio == null) { relatorioIdentidadeRelatorio = new RelatorioIdentidadeMembroRelatorioHelper(_url, _db, _services, this); } return relatorioIdentidadeRelatorio; } }
        public IInscricaoAcaoHelper InscricoesAcao { get { if (inscricoesAcao == null) { inscricoesAcao = new InscricaoAcaoHelper(_url, _db, _services, this); } return inscricoesAcao; } }
        public IInscricaoAcaoRelatorioHelper incrioesAcaoRelatorio { get { { if (inscricoesAcoaRelatorio == null) { inscricoesAcoaRelatorio = new InscricaoAcaoRelatorioHelper(_url, _db, _services, this); } return inscricoesAcoaRelatorio; } } }
        public IFonteFinanceiraHelper FontesFinanceiras { get { if (this.fontesFinanceiras == null) { this.fontesFinanceiras = new FonteFinanceiraHelper(_url, _db, _services, this); } return this.fontesFinanceiras; } }

        public IAvaliacaoRelatorioPropostaHelper AvaliacoesRelatorios { get { if (this.avaliacoesRelatorios == null) { this.avaliacoesRelatorios = new AvaliacaoRelatorioPropostaHelper(_url, _db, _services, this); } return this.avaliacoesRelatorios; } }

        public IAvaliacaoRelatorioCamaraHelper AvaliacoesRelatoriosCamara { get { if (this.avaliacoesRelatoriosCamara == null) { this.avaliacoesRelatoriosCamara = new AvaliacaoRelatorioCamaraHelper(_url, _db, _services, this); } return this.avaliacoesRelatoriosCamara; } }

        public IAvaliadorPropostaHelper AvaliadoresProposta { get { if (this.avaliadoresProposta == null) { this.avaliadoresProposta = new AvaliadorPropostaHelper(_url, _db, _services, this); } return this.avaliadoresProposta; } }

        public IAvaliadorRelatorioHelper AvaliadoresRelatorio { get { if (this.avaliadoresRelatorio == null) { this.avaliadoresRelatorio = new AvaliadorRelatorioHelper(_url, _db, _services, this); } return this.avaliadoresRelatorio; } }

        #endregion

        
*/
        #endregion
        #region PRIVATE HELPERS' INSTANCES

        private LoggedUserHelper usuarioLogado { get; set; }
        private SelectListHelper selectLists { get; set; }
        //private ProjetoHelper projetos { get; set; }

        //private ProgramaHelper programas { get; set; }

        //private AcaoHelper acoes { get; set; }
        //private AcaoRelatorioHelper acoesrelatorio { get; set; }
        //private MembroEquipeHelper membrosEquipe { get; set; }
        //private MembroEquipeRelatorioHelper membrosEquipeRelatorio { get; set; }
        //private TurmaHelper turmas { get; set; }
        //private TurmaRelatorioHelper turmasRelatorio { get; set; }
        //private ProprietarioHelper proprietarios { get; set; }

        //private FuncaoMembroHelper funcoesMembro { get; set; }
        //private FuncaoMembroRelatorioHelper funcaoMembroRelatorio { get; set; }
        //private HomologacaoPropostaHelper homologacoes { get; set; }

        //private IPropostaHelper propostas { get; set; }

        //private SelectListHelper selectLists { get; set; }

        //private PublicoAlvoHelper publicosAlvo { get; set; }
        //private PublicoAlvoAcaoRelatorioHelper publicosAlvoAcaoRelatorio { get; set; }
        //private ProdutoHelper produtos { get; set; }
        //private ProdutoRelatorioHelper produtosRelatorio { get; set; }
        //private EditalHelper editais { get; set; }

        //private RecursoPropostaHelper recursosProposta { get; set; }

        //private AvaliacaoInstanciaSuperiorHelper avaliacaoInstanciaSuperior { get; set; }

        //private ProtocoloHelper protocolos { get; set; }

        //private CargaHorariaHelper cargaHoraria { get; set; }



        //private AvaliacaoPropostaHelper avaliacoesProposta { get; set; }

        //private RelatorioProgramaHelper relatoriosPrograma { get; set; }

        //private RelatorioProjetoHelper relatoriosProjeto { get; set; }

        //private RelatorioMembroEquipeHelper relatoriosMembroEquipe { get; set; }
        //private RelatorioMembroEquipeRelatorioHelper relatoriosMembroEquipeRelatorio { get; set; }

        //private RelatorioAcaoHelper relatoriosAcao { get; set; }
        //private RelatorioAcaoRelatorioHelper relatoriosAcaoRelatorio { get; set; }
        //private RelatorioIdentidadeMembroHelper relatoriosIdentidade { get; set; }
        //private RelatorioIdentidadeMembroRelatorioHelper relatorioIdentidadeRelatorio { get; set; }
        //private InscricaoAcaoHelper inscricoesAcao { get; set; }
        //private InscricaoAcaoRelatorioHelper inscricoesAcoaRelatorio { get; set; }
        //private FonteFinanceiraHelper fontesFinanceiras { get; set; }

        //private IAvaliacaoRelatorioPropostaHelper avaliacoesRelatorios { get; set; }

        //private IAvaliacaoRelatorioCamaraHelper avaliacoesRelatoriosCamara { get; set; }

        //private IAvaliadorPropostaHelper avaliadoresProposta { get; set; }

        //private IAvaliadorRelatorioHelper avaliadoresRelatorio { get; set; }
        #endregion
    }
}