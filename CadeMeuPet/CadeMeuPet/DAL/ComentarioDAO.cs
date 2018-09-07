using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadeMeuPet.DAL
{
    public class ComentarioDAO
    {
        private static Context ctx = Singleton.Singleton.GetInstance();

        #region Salvar Comentário
        public static bool CadastrarComentario(Comentario comentario)
        {
            try
            {
                if (BuscarById(comentario.idComentario) == null)
                {
                    ctx.Comentarios.Add(comentario);
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

        #region Buscar Comentários
        public static List<Comentario> BuscarComentarios()
        {
            return ctx.Comentarios.Include("Animal").ToList();
        }
        #endregion

        #region Buscar Comentários Pelo Nome da pessoa que comentou
        public static List<Comentario> BuscarByName(Comentario comentario)
        {
            return ctx.Comentarios.Where(x => x.NomeComentario == comentario.NomeComentario).ToList();
        }
        #endregion

        #region Buscar Comentário Pelo id
        public static Comentario BuscarById(int id)
        {
            return ctx.Comentarios.Where(x => x.idComentario == id).FirstOrDefault();
        }
        #endregion

        #region Remover Comentário
        public static void RemoverComentario(int id)
        {

            Comentario comentario = BuscarById(id);
            ctx.Comentarios.Remove(comentario);
            ctx.SaveChanges();

        }
        #endregion


    }
}