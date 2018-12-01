using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;



namespace XF.Login.Model
{

    public class Usuario
    {
        public string idUsuario { get; set; }
        public string nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; }

    }

    public class Header
    {
        public string previousClass { get; set; }
        public string previous { get; set; }
        public string nextClass { get; set; }
        public string next { get; set; }
        public string pageCount { get; set; }
        public string pageNow { get; set; }
        public List<Usuario> data { get; set; }

    }

    public class UsuarioRepository
    {
        private UsuarioRepository() { }

        private static readonly UsuarioRepository instance = new UsuarioRepository();
        public static UsuarioRepository Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool IsAutorizado(Usuario paramLogin)
        {

            var result = JsonConvert.DeserializeObject<Header>(App.UsuarioVM.Stream);
            var usuarios = new List<Usuario>();
            //var usuario = new Usuario();


            foreach (var item in result.data.ToList())
            {
                Usuario usuario = new Usuario()
                {
                    Email = item.Email,
                    Senha = item.Senha
                };
                usuarios.Add(usuario);
            }

            return usuarios.Any(user => user.Email == paramLogin.Email && user.Senha == paramLogin.Senha);
          
        }
    }

}
