using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CadeMeuPet.Models;

namespace CadeMeuPet.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = Singleton.Singleton.GetInstance();

        #region SALVAR USUARIO

        public static bool SalvarUsuario(Usuario usuario)
        {
            try
            {
                if (BuscarUsuarioPorUserName(usuario) == null)
                {
                    ctx.Usuarios.Add(usuario);
                    ctx.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                string error;
                error = e.Message;
                return false;
            }
            

        }
        #endregion

        #region BUSCAR USUARIO POR USERNAME

        public static Usuario BuscarUsuarioPorUserName(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.UserName.Equals(usuario.UserName));
        }


        #endregion

        #region LISTAR USUARIOS

        public static List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }


        #endregion

        #region BUSCAR USUARIOS POR ID

        public static Usuario BuscarUsuarioPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        #endregion

        #region ALTERAR USUARIO

        public static bool AlterarUsuario(Usuario usuario)
        {
            if (ctx.Usuarios.FirstOrDefault(x => x.UserName.Equals(usuario.UserName)
            && x.Password.Equals(usuario.Password) && x.UsuarioId == usuario.UsuarioId) != null)
            {
                ctx.Entry(usuario).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion

        #region EXCLUIR USUARIO

        public static void ExcluirUsuario(int id)
        {
            Usuario usuario = new Usuario();
            usuario = BuscarUsuarioPorId(id);
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();

        }

        #endregion

    }
}