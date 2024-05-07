using Mscc.GenerativeAI;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using UC.Models.UCEntityHelpers.Interfaces;

namespace UC.Models.UCEntityHelpers
{
    public class GeminiHelper : BaseHelper, IGeminiHelper
    {
        #region CONSTRUCTORS

        public GeminiHelper(UrlHelper _url, UCDBContext _db, IUnityOfHelpers _helpers) : base(_url, _db, _helpers) { }

        #endregion
        #region METHODS
        public bool EnviarRequisicao(string prompt, out string resultado)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

                var genai = new GoogleAI(apiKey);

                var model = genai.GenerativeModel();

                var response = model.GenerateContent(prompt).Result;

                resultado = response.Text;

                return true;
            }
            catch(Exception ex)
            {
                resultado = $"Erro ao realizar requisição ao gemini. Confira: {ex.Message}";

                return false;
            }
        }

        public async Task<string> EnviarRequisicaoAsync(string prompt)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

                var genai = new GoogleAI(apiKey);

                var model = genai.GenerativeModel(model: Model.Gemini15Pro);

                var response = await model.GenerateContent(prompt);

                return response.Text;
            }
            catch (Exception ex)
            {
                return $"Erro ao realizar requisição ao gemini. Confira: {ex.Message}";
            }
        }

        #endregion
    }
}