//using UC.AutenticacaoService;
using UC.Controllers;
using UC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;

namespace UC.Utility
{
    /// <summary>
    /// Session persister for login managment.
    /// </summary>
    public class SimpleSessionPersister
    {
        #region KEY NAMES TO SESSION VALUES

        private const string usernameSessionVar = "username";
        private const string idSessionVar = "id";
        private const string userRoleSessionVar = "sessionStringRole";
        private const string userManyRolesVar = "sessionBoolManyRolesValue";
        private const string isLogged = "sessionUserIsLoggedValue";

        private const string returnLink_field = "afashfsldfhsadkjhsakl";
        #endregion

        #region SETTERS AND UNSETTERS

        /// <summary>
        /// Set values on the SimpleSessionPersister.
        /// </summary>
        /// <param name="Id">The user's identification.</param>
        /// <param name="Username">The user's name.</param>
        /// <param name="UserRole">The user's role on the application.</param>
        /// <param name="UserHasOtherRoles">Indicates if the user can change to other roles in the application.</param>
        /// <exception cref="ArgumentException">One or more arguments do not attend the SimpleSessionPersister's specifications.</exception>
        private static void SetValues(string Id, string Username, string UserRole, bool UserHasOtherRoles)
        {
            if (string.IsNullOrWhiteSpace(UserRole))
            {
                throw new ArgumentException("Perfil do usuário não pode ser vazio.", "UserRole");
            }

            SimpleSessionPersister.Id = Id;
            SimpleSessionPersister.Username = Username;
            SimpleSessionPersister.UserRole = UserRole;
            SimpleSessionPersister.UserHasOtherRoles = UserHasOtherRoles;
            SimpleSessionPersister.IsLogged = true;
        }

        /// <summary>
        /// Clear all data in the SimpleSessionPersister.
        /// </summary>
        private static void Clear()
        {
            LogOut();
        }

        public static void Logar(Pessoa pessoa)
        {
            var tipo = ((TipoLogin)pessoa.nivelAcesso).ToString();
            SetValues(pessoa.pessoaUID.ToString(), pessoa.nome, tipo, false);
        }

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// The user's identification.
        /// </summary>
        public static string Id { get { if (HttpContext.Current == null) { return string.Empty; } var sessionVar = HttpContext.Current.Session[idSessionVar]; if (sessionVar != null) { return sessionVar as string; } return null; } private set { HttpContext.Current.Session[idSessionVar] = value; } }

        /// <summary>
        /// The user's name.
        /// </summary>
        public static string Username { get { if (HttpContext.Current == null) { return string.Empty; } var sessionVar = HttpContext.Current.Session[usernameSessionVar]; if (sessionVar != null) { return sessionVar as string; } return null; } private set { HttpContext.Current.Session[usernameSessionVar] = value; } }

        /// <summary>
        /// The user's role on the application.
        /// </summary>
        public static string UserRole { get { if (HttpContext.Current == null) { return string.Empty; } var sessionVar = HttpContext.Current.Session[userRoleSessionVar]; if (sessionVar != null) { return sessionVar as string; } return "Comum"; } private set { HttpContext.Current.Session[userRoleSessionVar] = value; } }

        /// <summary>
        /// Indicates if the user can change to other roles in the application.
        /// </summary>
        public static bool UserHasOtherRoles { get { if (HttpContext.Current == null) { return false; } var sessionVar = HttpContext.Current.Session[userManyRolesVar]; if (sessionVar != null) { return Convert.ToBoolean(sessionVar); } return false; } private set { HttpContext.Current.Session[userManyRolesVar] = value; } }

        /// <summary>
        /// Indicates if there's a valid user logged in the SimpleSessionPersister.
        /// </summary>
        public static bool IsLogged { get { if (HttpContext.Current == null) { return false; } var sessionVar = HttpContext.Current.Session[isLogged]; if (sessionVar != null) { return Convert.ToBoolean(sessionVar); } return false; } private set { HttpContext.Current.Session[isLogged] = value; } }
        #endregion

        #region RETURN METHODS

        public static bool HasReturnLink
        {
            get
            {
                return HttpContext.Current.Session[returnLink_field] != null;
            }
        }

        public static string ReturnLink
        {
            get
            {
                if (HttpContext.Current.Session[returnLink_field] != null)
                {
                    var aux = HttpContext.Current.Session[returnLink_field].ToString();

                    HttpContext.Current.Session[returnLink_field] = null;

                    return aux;
                }

                return string.Empty;
            }

            set
            {
                HttpContext.Current.Session[returnLink_field] = value;
            }
        }

        #endregion

        #region LOGIN METHODS
        /*
        public static void LoginServidor(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, bool variosPerfis)
        {
            LoginServidor(u, user, variosPerfis, null);
        }

        public static void LoginServidor(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, bool variosPerfis, long? servidorUID)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "Servidor", variosPerfis);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID, servidorUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "Servidor", variosPerfis);
        }

        public static void LoginAdministrador(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);
            SetValues(pessoa.cpf, pessoa.nome, "Administrador", true);
        }

        public static void LoginAvaliadorCamara(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            var p = LoadInfoServidor(u, user.pessoa.pessoaUID);
            SimpleSessionPersister.SetValues(p.cpf, p.nome, "AvaliadorCamara", true);
        }

        public static void LoginRelatorInstanciaSuperior(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "RelatorInstanciaSuperior", true);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "RelatorInstanciaSuperior", true);

        }

        public static void LoginInstanciaSuperior(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, long unidadeUID)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "InstanciaSuperior", true);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "InstanciaSuperior", true);

            var unidade = u.Services.Localizacao.GetUnidade(unidadeUID);

            if (unidade != null)
            {
                LoadInfoUnidade(unidade);
            }
            else
            {
                SimpleSessionPersister.LogOut();
                throw new Exception("Usuário não é responsável por nenhuma unidade.");
            }
        }

        private static PessoaService.PessoaEntity LoadInfoServidor(Models.IUnityOfHelpers u, long pessoaUID)
        {
            return LoadInfoServidor(u, pessoaUID, null);
        }

        private static PessoaService.PessoaEntity LoadInfoServidor(Models.IUnityOfHelpers u, long pessoaUID, long? svrUID)
        {
            PessoaService.PessoaEntity result = null;

            if (svrUID.HasValue)
            {
                result = u.Services.Pessoa.GetPessoaPorServidor(svrUID.Value);
            }
            else
            {
                result = u.Services.Pessoa.GetPessoaEntityPorSituacao(pessoaUID, u.MembrosEquipe.ServidoresQuePodemSerAdicionados);
            }

            if (result != null)
            {
                servidorUID = result.ServidorUID;

                if (result.Unidade != null)
                {
                    nomeCampus = result.Unidade.Campus;
                    unidadeUID = result.Unidade.UnidadeUID;
                    nomeUnidade = result.Unidade.Nome;
                    campusUID = (int)result.Unidade.CampusUID;
                }
                else
                {
                    SimpleSessionPersister.LogOut();
                    throw new Exception("Usuário não tem unidade lotacional. Favor entrar em contato com o seu chefe imediato para definir sua lotação e utilizar o sistema.");
                }

                var proprietario = u.Proprietarios.GetProprietario(result.ServidorUID);

                var pessoas = u.Services.Autenticacao.GetVinculosPorPessoaBySituacao(result.pessoaUID, false);

                if (pessoas.Count() > 0)
                {
                    List<Projeto> projetos = new List<Projeto>();
                    List<Programa> programas = new List<Programa>();

                    foreach (var cadaServidor in pessoas)
                    {
                        if (cadaServidor.servidorUID != result.ServidorUID)
                        {
                            var prop = u.Proprietarios.GetProprietario(cadaServidor.servidorUID);
                            if (prop != null)
                            {
                                projetos.AddRange(u.idbufmtContext.Projeto.Where(x => x.proprietarioUID == prop.proprietarioUID));
                                programas.AddRange(u.idbufmtContext.Programa.Where(x => x.proprietarioUID == prop.proprietarioUID));
                            }
                        }
                    }

                    if (projetos.Count > 0 || programas.Count > 0)
                    {
                        foreach (var cadaProjeto in projetos)
                        {
                            cadaProjeto.proprietarioUID = proprietario.proprietarioUID;
                        }

                        foreach (var cadaPrograma in programas)
                        {
                            cadaPrograma.proprietarioUID = proprietario.proprietarioUID;
                        }

                        u.idbufmtContext.SaveChanges();
                    }
                }

                proprietarioUID = proprietario.proprietarioUID;
            }
            else
            {
                SimpleSessionPersister.LogOut();
                throw new Exception("Não existe uma pessoa no sistema relacionada a esse login.");
            }

            return result;
        }

        public static void LoginAdmCamara(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, long permissaoUID)
        {
            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SalvarCampusDeAdmDeCâmara(u, permissaoUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "AdmCamara", true);
        }

        private static void SalvarCampusDeAdmDeCâmara(Models.IUnityOfHelpers u, long permissaoUID)
        {
            var listaDeCampi = u.Services.Localizacao.GetCampi(null);

            string nomeDoCampus = string.Empty;
            string campusUID = string.Empty;

            if (permissaoUID == Permissions.permissaoUID_CamaraCuiaba)
            { nomeDoCampus = "CUIABÁ"; }
            else
            {
                if (permissaoUID == Permissions.permissaoUID_CamaraRondonopolis)
                { nomeDoCampus = "RONDONÓPOLIS"; }
                else
                {
                    if (permissaoUID == Permissions.permissaoUID_CamaraAraguaia)
                    { nomeDoCampus = "ARAGUAIA"; }
                    else
                    {
                        if (permissaoUID == Permissions.permissaoUID_CamaraSinop)
                        { nomeDoCampus = "SINOP"; }
                        else
                        {
                            if (permissaoUID == Permissions.permissaoUID_CamaraVG)
                            { nomeDoCampus = "VÁRZEA GRANDE"; }
                            else
                            { throw new Exception("Tipo de permissão de Câmara desconhecida."); }
                        }
                    }
                }
            }

            var c = listaDeCampi.FirstOrDefault(x => x.Nome.Contains(nomeDoCampus));

            if (c != null)
            {
                LoadInfoCampus(c);
            }
        }

        public static void LoginEstudante(Models.IUnityOfHelpers u, AutenticacaoService.Aluno aluno)
        {
            switch (aluno.tipoEstudante)
            {
                case AutenticacaoService.TipoEstudante.Graduacao:
                    {
                        SimpleSessionPersister.SetValues(aluno.Rga, aluno.NomeAluno, "Estudante", false);
                        break;
                    }

                case AutenticacaoService.TipoEstudante.PosGraduacao:
                    {
                        throw new Exception("Login de Estudante de Pós-Graduação ainda não está disponível.");
                    }

                default:
                    {
                        throw new Exception("Tipo de Estudante não definido para a aplicação.");
                    }
            }

            nomeCampus = aluno.NomeCampus;

            var prop = u.Proprietarios.GetProprietario(aluno.Rga);

            proprietarioUID = prop.proprietarioUID;
        }

        private static void LoadInfoCampus(LocalizacaoService.CampusEntity campus)
        {
            campusUID = campus.CampusUID;
            nomeCampus = campus.Nome;
        }
        public static void LoginServidor(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, bool variosPerfis)
        {
            LoginServidor(u, user, variosPerfis, null);
        }

        public static void LoginServidor(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, bool variosPerfis, long? servidorUID)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "Servidor", variosPerfis);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID, servidorUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "Servidor", variosPerfis);
        }

        public static void LoginAdministrador(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);
            SetValues(pessoa.cpf, pessoa.nome, "Administrador", true);
        }

        public static void LoginAvaliadorCamara(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            var p = LoadInfoServidor(u, user.pessoa.pessoaUID);
            SimpleSessionPersister.SetValues(p.cpf, p.nome, "AvaliadorCamara", true);
        }

        public static void LoginRelatorInstanciaSuperior(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "RelatorInstanciaSuperior", true);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "RelatorInstanciaSuperior", true);

        }

        public static void LoginInstanciaSuperior(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, long unidadeUID)
        {
            SimpleSessionPersister.SetValues(string.Empty, string.Empty, "InstanciaSuperior", true);

            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "InstanciaSuperior", true);

            var unidade = u.Services.Localizacao.GetUnidade(unidadeUID);

            if (unidade != null)
            {
                LoadInfoUnidade(unidade);
            }
            else
            {
                SimpleSessionPersister.LogOut();
                throw new Exception("Usuário não é responsável por nenhuma unidade.");
            }
        }

        private static PessoaService.PessoaEntity LoadInfoServidor(Models.IUnityOfHelpers u, long pessoaUID)
        {
            return LoadInfoServidor(u, pessoaUID, null);
        }

        private static PessoaService.PessoaEntity LoadInfoServidor(Models.IUnityOfHelpers u, long pessoaUID, long? svrUID)
        {
            PessoaService.PessoaEntity result = null;

            if (svrUID.HasValue)
            {
                result = u.Services.Pessoa.GetPessoaPorServidor(svrUID.Value);
            }
            else
            {
                result = u.Services.Pessoa.GetPessoaEntityPorSituacao(pessoaUID, u.MembrosEquipe.ServidoresQuePodemSerAdicionados);
            }

            if (result != null)
            {
                servidorUID = result.ServidorUID;

                if (result.Unidade != null)
                {
                    nomeCampus = result.Unidade.Campus;
                    unidadeUID = result.Unidade.UnidadeUID;
                    nomeUnidade = result.Unidade.Nome;
                    campusUID = (int)result.Unidade.CampusUID;
                }
                else
                {
                    SimpleSessionPersister.LogOut();
                    throw new Exception("Usuário não tem unidade lotacional. Favor entrar em contato com o seu chefe imediato para definir sua lotação e utilizar o sistema.");
                }

                var proprietario = u.Proprietarios.GetProprietario(result.ServidorUID);

                var pessoas = u.Services.Autenticacao.GetVinculosPorPessoaBySituacao(result.pessoaUID, false);

                if (pessoas.Count() > 0)
                {
                    List<Projeto> projetos = new List<Projeto>();
                    List<Programa> programas = new List<Programa>();

                    foreach (var cadaServidor in pessoas)
                    {
                        if (cadaServidor.servidorUID != result.ServidorUID)
                        {
                            var prop = u.Proprietarios.GetProprietario(cadaServidor.servidorUID);
                            if (prop != null)
                            {
                                projetos.AddRange(u.idbufmtContext.Projeto.Where(x => x.proprietarioUID == prop.proprietarioUID));
                                programas.AddRange(u.idbufmtContext.Programa.Where(x => x.proprietarioUID == prop.proprietarioUID));
                            }
                        }
                    }

                    if (projetos.Count > 0 || programas.Count > 0)
                    {
                        foreach (var cadaProjeto in projetos)
                        {
                            cadaProjeto.proprietarioUID = proprietario.proprietarioUID;
                        }

                        foreach (var cadaPrograma in programas)
                        {
                            cadaPrograma.proprietarioUID = proprietario.proprietarioUID;
                        }

                        u.idbufmtContext.SaveChanges();
                    }
                }

                proprietarioUID = proprietario.proprietarioUID;
            }
            else
            {
                SimpleSessionPersister.LogOut();
                throw new Exception("Não existe uma pessoa no sistema relacionada a esse login.");
            }

            return result;
        }

        public static void LoginAdmCamara(Models.IUnityOfHelpers u, AutenticacaoService.Usuario user, long permissaoUID)
        {
            var pessoa = LoadInfoServidor(u, user.pessoa.pessoaUID);

            SalvarCampusDeAdmDeCâmara(u, permissaoUID);

            SimpleSessionPersister.SetValues(pessoa.cpf, pessoa.nome, "AdmCamara", true);
        }

        private static void SalvarCampusDeAdmDeCâmara(Models.IUnityOfHelpers u, long permissaoUID)
        {
            var listaDeCampi = u.Services.Localizacao.GetCampi(null);

            string nomeDoCampus = string.Empty;
            string campusUID = string.Empty;

            if (permissaoUID == Permissions.permissaoUID_CamaraCuiaba)
            { nomeDoCampus = "CUIABÁ"; }
            else
            {
                if (permissaoUID == Permissions.permissaoUID_CamaraRondonopolis)
                { nomeDoCampus = "RONDONÓPOLIS"; }
                else
                {
                    if (permissaoUID == Permissions.permissaoUID_CamaraAraguaia)
                    { nomeDoCampus = "ARAGUAIA"; }
                    else
                    {
                        if (permissaoUID == Permissions.permissaoUID_CamaraSinop)
                        { nomeDoCampus = "SINOP"; }
                        else
                        {
                            if (permissaoUID == Permissions.permissaoUID_CamaraVG)
                            { nomeDoCampus = "VÁRZEA GRANDE"; }
                            else
                            { throw new Exception("Tipo de permissão de Câmara desconhecida."); }
                        }
                    }
                }
            }

            var c = listaDeCampi.FirstOrDefault(x => x.Nome.Contains(nomeDoCampus));

            if (c != null)
            {
                LoadInfoCampus(c);
            }
        }

        public static void LoginEstudante(Models.IUnityOfHelpers u, AutenticacaoService.Aluno aluno)
        {
            switch (aluno.tipoEstudante)
            {
                case AutenticacaoService.TipoEstudante.Graduacao:
                    {
                        SimpleSessionPersister.SetValues(aluno.Rga, aluno.NomeAluno, "Estudante", false);
                        break;
                    }

                case AutenticacaoService.TipoEstudante.PosGraduacao:
                    {
                        throw new Exception("Login de Estudante de Pós-Graduação ainda não está disponível.");
                    }

                default:
                    {
                        throw new Exception("Tipo de Estudante não definido para a aplicação.");
                    }
            }

            nomeCampus = aluno.NomeCampus;

            var prop = u.Proprietarios.GetProprietario(aluno.Rga);

            proprietarioUID = prop.proprietarioUID;
        }

        private static void LoadInfoCampus(LocalizacaoService.CampusEntity campus)
        {
            campusUID = campus.CampusUID;
            nomeCampus = campus.Nome;
        }*/

        public static void LogOut()
        {
            SimpleSessionPersister.Id = null;
            SimpleSessionPersister.Username = null;
            SimpleSessionPersister.UserRole = null;
            SimpleSessionPersister.UserHasOtherRoles = false;
            SimpleSessionPersister.IsLogged = false;
        }

        #endregion
    }
}