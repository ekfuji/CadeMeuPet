using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CadeMeuPet.Models;
using Microsoft.Ajax.Utilities;
using Context = CadeMeuPet.Models.Context;

namespace CadeMeuPet.DAL
{
    public class EnderecoDAO
    {

        private static Context ctx = Singleton.Singleton.GetInstance();


        #region CADASTRAR ENDERECO

        public static bool CadastrarEndereco(Endereco endereco)
        {
            try
            {
                if (BuscarEnderecoById(endereco.EnderecoId) == null)
                {
                    ctx.Enderecos.Add(endereco);
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

        #region BUSCAR ENDEREÇO BY ID

        public static Endereco BuscarEnderecoById(int id)
        {
            return ctx.Enderecos.FirstOrDefault(e => e.EnderecoId == id);
        }

        #endregion

        #region LISTAR ENDEREÇOS

        public static List<Endereco> ListarEnderecos()
        {
            return ctx.Enderecos.ToList();
        }

        #endregion

        #region BUSCAR ENDEREÇO BY CEP

        public static Endereco BuscarEnderecoByCEP(string CEP)
        {
            return ctx.Enderecos.FirstOrDefault(e => e.CEP.Equals(CEP));
        }



        #endregion

        #region EXCLUIR ENDEREÇO

        public static void ExcluirEndereco(int id)
        {
            Endereco endereco = new Endereco();
            endereco = BuscarEnderecoById(id);
            ctx.Enderecos.Remove(endereco);
            ctx.SaveChanges();

        }

        #endregion

        #region ALTERAR ENDEREÇO

        public static bool AlterarEndereco(Endereco endereco)
        {
            if (ctx.Enderecos.FirstOrDefault(e => e.Logradouro.Equals(endereco.Logradouro) && e.EnderecoId != endereco.EnderecoId) == null)
            {
                ctx.Entry(endereco).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }


        #endregion
    }
}