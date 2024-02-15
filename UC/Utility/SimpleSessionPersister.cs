//using UC.AutenticacaoService;
using UC.Controllers;
using UC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UC.Models.Enumerators;
using System.EnterpriseServices;
using Google.Protobuf.WellKnownTypes;

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
            SimpleSessionPersister.usuarioUID = long.Parse(Id);
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

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// The user's identification.
        /// </summary>
        public static string Id { get { if (HttpContext.Current == null) { return string.Empty; } var sessionVar = HttpContext.Current.Session[idSessionVar]; if (sessionVar != null) { return sessionVar as string; } return null; } private set { HttpContext.Current.Session[idSessionVar] = value; } }

        public static long usuarioUID { get { if (IsLogged) { return long.Parse(Id); } return 0; } set { Id = value.ToString(); } }

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
        public static void LoginUsuario(Usuario user)
        {
            SimpleSessionPersister.SetValues(user.usuarioUID.ToString(), user.nome, "Comum", false);
        }

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