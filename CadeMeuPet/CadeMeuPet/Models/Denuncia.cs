using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Denuncia")]
    public class Denuncia
    {
        public int DenunciaId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Data do Comentário")]
        public DateTime DataDenuncia { get; set; } = DateTime.Now;

        [Column(TypeName = "VARCHAR")]
        [MaxLength(45, ErrorMessage = "O motivo deve ter no máximo 45 caracteres")]
        [Display(Name = "Motivo")]
        public string Motivo { get; set; }

        [Display(Name = "Animal")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}