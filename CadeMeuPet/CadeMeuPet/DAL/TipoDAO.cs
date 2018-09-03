using CadeMeuPet.Models;
using CadeMeuPet.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CadeMeuPet.DAL
{
    public class TipoDAO
    {
        private static Context ctx = Singleton.Singleton.GetInstance();

        #region Salvar Tipo
        public static bool CadastrarTipo(Tipo tipo)
        {
            try
            {
                if (BuscarByName(tipo) == null)
                {
                    ctx.Tipos.Add(tipo);
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

        #region Buscar Tipos
        public static List<Tipo> BuscarTipos()
        {
            return ctx.Tipos.ToList();
        }
        #endregion

        #region Buscar tipo pelo nome
        public static Tipo BuscarByName(Tipo tipo)
        {
            return ctx.Tipos.Where(x => x.Especie == tipo.Especie).FirstOrDefault();
        }
        #endregion

        #region Buscar Tipo pelo id
        public static Tipo BuscarById(int id)
        {
            return ctx.Tipos.Where(x => x.TipoId == id).FirstOrDefault();
        }
        #endregion

        #region Alterar Tipo
        public static bool AlterarTipo(Tipo tipo)
        {

            if (ctx.Tipos.FirstOrDefault(x => x.Especie.Equals(tipo.Especie) && x.TipoId != tipo.TipoId) == null)
            {
                ctx.Entry(tipo).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region Remover Tipo
        public static bool RemoverTipo(int id)
        {
            Tipo tipo = new Tipo();
             tipo = BuscarById(id);
            if(tipo != null)
            {
                ctx.Tipos.Remove(tipo);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

    }
}