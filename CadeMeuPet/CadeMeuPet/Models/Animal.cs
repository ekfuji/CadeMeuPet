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
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Características")]
        [MaxLength(200, ErrorMessage = "O campo deve ter no máximo 200 caracteres")]
        public string Características { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O campo visto pela ultima vez é obrigatório")]
        [Display(Name = "Visto pela ultima vez")]
        [MaxLength(200, ErrorMessage = "O campo deve ter no máximo 200 caracteres")]
        public string VistoPelaUltimaVez { get; set; }

        [Column(TypeName = "BINARY")]
        public byte Situacao { get; set; } 

        [Required(ErrorMessage = "o Porte é obrigatório")]
        [Display(Name = "Tamnho")]
        public int PorteId { get; set; }

        public virtual Porte Porte { get; set; }

        [Display(Name = "Comentário")]
        public int ComentarioId { get; set; }

        public virtual Comentario Comentario { get; set; }

        [Required(ErrorMessage = "o Tipo é obrigatório")]
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        public virtual Tipo Tipo { get; set; }
    }
}