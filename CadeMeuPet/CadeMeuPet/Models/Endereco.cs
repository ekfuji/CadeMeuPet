using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(150, ErrorMessage = "O endereço deve ter no máximo 150 caracteres!")]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(8, ErrorMessage = "O CEP deve ter no máximo 8 caracteres!")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Latitude")]
        [Column(TypeName = "VARCHAR")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Column(TypeName = "VARCHAR")]
        public string Longitude { get; set; }

        [Display(Name = "IP")]
        [Column(TypeName = "VARCHAR")]
        public String Ip { get; set; }

        [Display(Name = "Navegador")]
        [Column(TypeName = "VARCHAR")]
        public String Navegador { get; set; }

    }
}