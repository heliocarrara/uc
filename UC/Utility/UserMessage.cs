using System;

namespace UC.Utility
{
    /// <summary>
    /// Classe para auxiliar a exibição de mensagens para o usuário.
    /// </summary>
    public class UserMessage
    {
        #region CONSTRUCTORS

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="ex">Exceção que será usada para a construção da mensagem exibida.</param>
        public UserMessage(Exception ex) : this(ex.Message, null, ex.HelpLink, null, "danger") { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        public UserMessage(string message) : this(message, null) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        public UserMessage(string message, string title) : this(message, title, null) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        /// <param name="url">URL para visualização ou resolução do problema apresentado para o usuário.</param>
        public UserMessage(string message, string title, string url) : this(message, title, url, null) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        /// <param name="url">URL para visualização ou resolução do problema apresentado para o usuário.</param>
        /// <param name="assistiveText">Mensagem assistiva para acessibilidade da mensagem.</param>
        public UserMessage(string message, string title, string url, string assistiveText) : this(message, title, url, assistiveText, null) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        /// <param name="url">URL para visualização ou resolução do problema apresentado para o usuário.</param>
        /// <param name="assistiveText">Mensagem assistiva para acessibilidade da mensagem.</param>
        /// <param name="alertType">Tipo de alerta do Bootstrap que será usado para a mensagem.</param>
        public UserMessage(string message, string title, string url, string assistiveText, string alertType) : this(message, title, url, assistiveText, alertType, null) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        /// <param name="url">URL para visualização ou resolução do problema apresentado para o usuário.</param>
        /// <param name="assistiveText">Mensagem assistiva para acessibilidade da mensagem.</param>
        /// <param name="alertType">Tipo de alerta do Bootstrap que será usado para a mensagem.</param>
        /// <param name="glyphicon">Tipo de Glyphicon do Bootstrap utilizado na mensagem.</param>
        public UserMessage(string message, string title, string url, string assistiveText, string alertType, string glyphicon) : this(message, title, url, assistiveText, assistiveText, glyphicon, true) { }

        /// <summary>
        /// Inicializa uma nova instância da classe UserMessage.
        /// </summary>
        /// <param name="message">Mensagem que será exibida para o usuário.</param>
        /// <param name="title">O título da mensagem que será exibida para o usuário.</param>
        /// <param name="url">URL para visualização ou resolução do problema apresentado para o usuário.</param>
        /// <param name="assistiveText">Mensagem assistiva para acessibilidade da mensagem.</param>
        /// <param name="alertType">Tipo de alerta do Bootstrap que será usado para a mensagem.</param>
        /// <param name="glyphicon">Tipo de Glyphicon do Bootstrap utilizado na mensagem.</param>
        /// <param name="dismissible">Indica se a mensagem é dispensável na tela ou deve persistir.</param>
        public UserMessage(string message, string title, string url, string assistiveText, string alertType, string glyphicon, bool dismissible)
        {
            this.title = title;
            this.message = message;
            this.url = url;
            this.dismissible = dismissible;

            if (!string.IsNullOrEmpty(alertType))
                this.alertType = alertType;

            if (!string.IsNullOrEmpty(assistiveText))
                this.assistiveText = assistiveText;

            if (!string.IsNullOrEmpty(glyphicon))
                this.glyphicon = glyphicon;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// O título da mensagem que será exibida para o usuário.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Mensagem assistiva para acessibilidade da mensagem.
        /// </summary>
        public string assistiveText { get; set; } = "Atenção";

        /// <summary>
        /// Mensagem que será exibida para o usuário.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// URL para visualização ou resolução do problema apresentado para o usuário.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Tipo de alerta do Bootstrap que será utilizado na mensagem.
        /// </summary>
        public string alertType { get; set; } = "info";

        /// <summary>
        /// Tipo de Glyphicon do Bootstrap que será utilizado na mensagem.
        /// </summary>
        public string glyphicon { get; set; }

        /// <summary>
        /// Indica se a mensagem deve ser dispensável ou persistir no momento da exibição.
        /// </summary>
        public bool dismissible { get; set; } = true;

        #endregion

        #region DERIVED PROPERTIES

        /// <summary>
        /// Indica se existe uma URL na propriedade url.
        /// </summary>
        public bool hasUrl { get { return !string.IsNullOrEmpty(this.url); } }

        #endregion
    }
}