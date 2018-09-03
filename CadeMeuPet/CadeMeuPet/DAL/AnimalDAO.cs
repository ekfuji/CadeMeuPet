﻿using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadeMeuPet.DAL
{
    public class AnimalDAO
    {
        private static Context ctx = Singleton.Singleton.GetInstance();

        #region Salvar Animal
        public static bool CadastrarAnimal(Animal animal)
        {
            try
            {
                if (animal != null)
                {
                    ctx.Animais.Add(animal);
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

        // é provável que o método abaixo precise de alterações (por causa do includes que talvez necessitaremos) 
        #region Buscar Animais
        public static List<Animal> BuscarAnimais()
        {
            return ctx.Animais.ToList();
        }
        #endregion

        #region Buscar Animais Pelo Nome
        public static List<Animal> BuscarByName(Animal animal)
        {
            return ctx.Animais.Where(x => x.NomeAnimal == animal.NomeAnimal).ToList();
        }
        #endregion

        #region Buscar Animal Pelo id
        public static Animal BuscarById(int id)
        {
            return ctx.Animais.Where(x => x.AnimalId == id).FirstOrDefault();
        }
        #endregion

        #region Remover Animal
        public static void RemoverAnima(int id)
        {
            Animal animal = new Animal();
            animal = BuscarById(id);
            ctx.Animais.Remove(animal);
            ctx.SaveChanges();

        }
        #endregion

        #region Alterar Animal
        public static bool AlterarAnimal(Animal animal)
        {
            if (ctx.Animais.FirstOrDefault(x =>  x.AnimalId != animal.AnimalId) == null)
            {
                ctx.Entry(animal).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

    }
}