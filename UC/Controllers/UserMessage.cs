using UC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UC.Controllers
{
    /// <summary>
    /// Controller de gerenciamento de Mensagens para Usuário.
    /// </summary>
    public abstract class UserMessageController : Controller
    {
        /// <summary>
        /// Adiciona uma mensagem para ser exibida para o usuário.
        /// </summary>
        /// <param name="type">Indica o tipo de mensagem e em que lista ela será adicionada.</param>
        /// <param name="message">A mensagem que será exibida para o usuário.</param>
        public void AddMessage(UserMessageType type, string message)
        {
            AddMessage(type, new UserMessage(message));
        }

        /// <summary>
        /// Adiciona uma mensagem para ser exibida para o usuário.
        /// </summary>
        /// <param name="type">Indica o tipo de mensagem e em que lista ela será adicionada.</param>
        /// <param name="exception">A exceção que será usada para a construção da mensagem.</param>
        public void AddMessage(UserMessageType type, Exception exception)
        {
            if (exception != null && exception.Message != "Exceção do tipo 'System.Exception' foi acionada.")
                AddMessage(type, new UserMessage(exception));
        }

        /// <summary>
        /// Adiciona uma mensagem para ser exibida para o usuário.
        /// </summary>
        /// <param name="type">Indica o tipo de mensagem e em que lista ela será adicionada.</param>
        /// <param name="message">A mensagem que será exibida para o usuário.</param>
        public void AddMessage(UserMessageType type, UserMessage message)
        {
            if (message != null)
            {
                var list = GetMessages(type);
                list.Add(message);
                AddMessages(type, list);
            }
        }

        /// <summary>
        /// Adiciona as mensagens de erro de um modelStateDictionary para serem exibidas para o usuário.
        /// </summary>
        /// <param name="type">Indica o tipo de mensagens e em que lista elas serão adicionadas.</param>
        /// <param name="modelState">O dicionário de estado de uma tentativa de modelbinding.</param>
        public void AddMessage(UserMessageType type, ModelStateDictionary modelState)
        {
            if (ModelState != null)
            {
                foreach (var item in modelState.Values)
                {
                    foreach (var i in item.Errors)
                    {
                        if (String.IsNullOrEmpty(i.ErrorMessage))
                        {
                            AddMessage(type, i.Exception != null ? i.Exception.Message : string.Empty);
                        }
                        else
                        {
                            AddMessage(type, i.ErrorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adiciona uma lista de mensagens para serem exibidas para o usuário.
        /// </summary>
        /// <param name="type">Indica o tipo de mensagens e em que lista elas serão adicionadas.</param>
        /// <param name="list">A lista de mensagens que será adicionada.</param>
        public static void AddMessages(UserMessageType type, List<UserMessage> list)
        {
            string alert_type = AlertType(type);
            string glyphicon = Glyphicon(type);

            foreach (var message in list)
            {
                message.alertType = alert_type;
                message.glyphicon = glyphicon;
            }

            var currentList = GetMessages(type);

            currentList.AddRange(list);

            string key = type.ToString();

            System.Web.HttpContext.Current.Session[key] = currentList;
        }

        /// <summary>
        /// Recupera a lista de mensagens atual do tipo indicado.
        /// </summary>
        /// <param name="type">O tipo de lista de mensagens que será recuperada.</param>
        /// <returns>A lista de mensagens do tipo indicado.</returns>
        public static List<UserMessage> GetMessages(UserMessageType type)
        {
            string key = type.ToString();

            List<UserMessage> result;

            if (System.Web.HttpContext.Current.Session[key] != null)
            {
                result = (List<UserMessage>)System.Web.HttpContext.Current.Session[key];
            }
            else
            {
                result = new List<UserMessage>();
            }

            System.Web.HttpContext.Current.Session[key] = null;
            return result;
        }

        /// <summary>
        /// Limpa todas as listas de mensagens que não foram exibidas.
        /// </summary>
        public void ClearAllUserMessages()
        {
            foreach (UserMessageType type in Enum.GetValues(typeof(UserMessageType)))
            {
                ClearMessages(type);
            }
        }

        /// <summary>
        /// Limpa a lista de mensagens do tipo indicado.
        /// </summary>
        /// <param name="type">O tipo de lista de mensagens que será limpa.</param>
        public void ClearMessages(UserMessageType type)
        {
            GetMessages(type);
        }

        /// <summary>
        /// Retorna um Alert-Type padrão para o tipo de lista de mensagens.
        /// </summary>
        /// <param name="type">O tipo de lista de mensagens.</param>
        /// <returns>Alert-type para ser utilizado na construção da mensagem em tela para o usuário.</returns>
        private static string AlertType(UserMessageType type)
        {
            switch (type)
            {
                case UserMessageType.error: { return "danger"; }
                case UserMessageType.success: { return "success"; }
                case UserMessageType.warning: { return "warning"; }
                default: { return "info"; }
            }
        }

        /// <summary>
        /// Retorna um Glyphicon padrão para o tipo de lista de mensagens.
        /// </summary>
        /// <param name="type">O tipo de lista de mensagens.</param>
        /// <returns>Glyphicon para ser utilizado na construção da mensagem em tela para o usuário.</returns>
        private static string Glyphicon(UserMessageType type)
        {
            switch (type)
            {
                case UserMessageType.error: { return "glyphicon glyphicon-exclamation-sign"; }
                case UserMessageType.success: { return "glyphicon glyphicon-ok"; }
                case UserMessageType.warning: { return "glyphicon glyphicon-warning-sign"; }
                default: { return "glyphicon glyphicon-info-sign"; }
            }
        }
    }

    /// <summary>
    /// Listagem que define os tipos de lista utilizadas no sistema.
    /// </summary>
    public enum UserMessageType
    {
        error, success, info, warning
    }
}
