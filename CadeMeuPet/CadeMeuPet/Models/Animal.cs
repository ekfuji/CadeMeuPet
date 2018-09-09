using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(45,ErrorMessage ="O campo deve ter no máximo 45 caracteres")]
        public string NomeAnimal { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Imagem { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Características")]
        [MaxLength(200, ErrorMessage = "O campo deve ter no máximo 200 caracteres")]
        public string Caracteristicas { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro{ get; set; } = DateTime.Now;

        [Display(Name = "Status publicação")]
        public byte Situacao { get; set; } 

        [Required(ErrorMessage = "o Porte é obrigatório")]
        [Display(Name = "Tamnho")]
        public int PorteId { get; set; }

        public virtual Porte Porte { get; set; }

        [Required(ErrorMessage = "o Tipo é obrigatório")]
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        public virtual Tipo Tipo { get; set; }

        [Display(Name ="Usuário")]
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }


    }
}