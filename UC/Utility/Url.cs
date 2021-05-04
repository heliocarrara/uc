using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UC.Utility
{
    public class Url
    {
        #region CONSTRUCTORS

        public Url(string url) : this(url, null) { }

        public Url(string url, string text) : this(url, text, null) { }

        public Url(string url, string text, string title) : this(url, text, title, linkTarget._self) { }

        public Url(string url, string text, string title, linkTarget target)
        {
            throw new NotImplementedException();

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Valor da URL não pode ser nulo ou vazio.", "url");
            }

            this.url = url;
            this.title = title;
            this.target = target;
            if (!string.IsNullOrEmpty(text)) { this.text = text; }
        }

        #endregion

        #region PROPERTIES

        public string url { get; private set; }

        public linkTarget target { get; private set; } = linkTarget._self;

        public string text { get; private set; } = "Clique aqui.";

        public string title { get; private set; } = null;

        #endregion
    }

    public enum linkTarget
    {
        _blank,
        _parent,
        _self,
        _top
    }
}