using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadeMeuPet.DAL
{
    public class PorteDAO
    {

        private static Context ctx = Singleton.Singleton.GetInstance();

        #region Salvar Porte
        public static bool CadastrarPorte(Porte porte)
        {
            try
            {
                if (BuscarByName(porte) == null)
                {
                    ctx.Portes.Add(porte);
                    ctx.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                string error;
                error = ex.Message;
                return false;
            }
        }
        #endregion

        #region Buscar Porte
        public static List<Porte> BuscarPorte()
        {
            return ctx.Portes.ToList();
        }
        #endregion

        #region Buscar porte pelo nome
        public static Porte BuscarByName(Porte porte)
        {
            return ctx.Portes.Where(x =>  x.Tamanho == porte.Tamanho).FirstOrDefault();
        }
        #endregion

        #region Buscar Porte pelo id
        public static Porte BuscarById(int id)
        {
            return ctx.Portes.Where(x => x.PorteId == id).FirstOrDefault();
        }
        #endregion

        #region Alterar Porte
        public static bool AlterarPorte(Porte porte)
        {

            if (ctx.Portes.FirstOrDefault(x => x.Tamanho.Equals(porte.Tamanho) && x.PorteId != porte.PorteId) == null)
            {
                ctx.Entry(porte).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region Remover Porte
        public static bool RemoverPorte(int id)
        {
            Porte porte = new Porte();
            porte = BuscarById(id);
            if (porte != null)
            {
                ctx.Portes.Remove(porte);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

    }
}