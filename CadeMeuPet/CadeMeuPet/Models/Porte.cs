using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Porte")]
    public class Porte
    {
        [Key]
        public int PorteId { get; set; }


        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [MaxLength(45, ErrorMessage = "O campo deve ter no máximo de 45 caracteres!")]
        [Display(Name = "Tamanho padrão dos Animais")]
        public string Tamanho { get; set; }
    }
}