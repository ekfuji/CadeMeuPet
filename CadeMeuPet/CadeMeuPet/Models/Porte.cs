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

        [Display(Name ="Tamanho")]
        public string Tamanho { get; set; }
    }
}