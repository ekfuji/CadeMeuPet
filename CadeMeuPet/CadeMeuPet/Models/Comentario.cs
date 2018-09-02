using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        public int idComentario { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage ="O campo é obrigatório!")]
        [MaxLength(200,ErrorMessage ="A messagem deve ter no máximo 200 caracteres!")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentario")]
        public string Mensagem { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Data do Comentário")]
        public DateTime DataComentario { get; set; } = DateTime.Now;

        [Column(TypeName ="VARCHAR")]
        [MaxLength(45,ErrorMessage ="O nome deve ter no máximo 45 caracteres")]
        [Display(Name = "Nome")]
        public string NomeComentario { get; set; }

        [Column(TypeName ="VARCHAR")]
        [MaxLength(100, ErrorMessage ="O email deve ter no máximo 100 caracteres!")]
        [Display(Name = "Email")]
        public string EmailComentario { get; set; }

        [Display(Name = "Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}