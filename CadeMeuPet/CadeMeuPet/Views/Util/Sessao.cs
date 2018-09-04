using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Util
{
    public class Sessao
    {
        private static string NOME_SESSAO = "SessãoUsuario";

        private static string RetornaSessãoUsuario()
        {
            if (HttpContext.Current.Session[NOME_SESSAO] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSAO] = guid.ToString();
            }

            return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }

        private static string CriarSessaoNova()
        {
            Guid guid = Guid.NewGuid();
            HttpContext.Current.Session[NOME_SESSAO] = guid.ToString();
           return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }
    }
}