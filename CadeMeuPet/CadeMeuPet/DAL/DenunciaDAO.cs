using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuPet.DAL
{
    public class DenunciaDAO
    {
        public static Context ctx = Singleton.Singleton.GetInstance();

        #region Buscar Denúncia
        public static List<Denuncia> BuscarDenuncias()
        {
            return ctx.Denuncias.Include("Animal").ToList();
        }
        #endregion

        #region Salvar Denúncia
        public static void CadastrarDenuncia(Denuncia denuncia)
        {
            ctx.Denuncias.Add(denuncia);
            ctx.SaveChanges();
        }
        #endregion

        #region Buscar Denúncia Por Id
        public static Denuncia BuscarById(int id)
        {
            return ctx.Denuncias.FirstOrDefault(x => x.DenunciaId == id);
        }
        #endregion

        #region Remover Denúncia

        public static void RemoverDenuncia(int id)
        {
           Denuncia denuncia = BuscarById(id);
            ctx.Denuncias.Remove(denuncia);
            ctx.SaveChanges();
        }
        #endregion

    }
}