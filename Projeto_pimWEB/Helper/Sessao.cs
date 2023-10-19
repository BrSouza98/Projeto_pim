using Newtonsoft.Json;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreatSession_User(Funcionario func)
        {
            string ObjectJson = JsonConvert.SerializeObject(func);
            _httpContext.HttpContext.Session.SetString("SessionOn", ObjectJson);
        }

        public Funcionario GetSession()
        {
            string SessionUser = _httpContext.HttpContext.Session.GetString("SessionOn");
            if (string.IsNullOrEmpty(SessionUser)) return null;

            return JsonConvert.DeserializeObject<Funcionario>(SessionUser);
        }

        public void RemoveSession_User()
        {
            _httpContext.HttpContext.Session.Remove("SessionOn");
        }
    }
}
