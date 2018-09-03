using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(45, ErrorMessage = "O nome deve ter no máximo 45 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "o campo Login é obrigatório")]
        [MaxLength(20, ErrorMessage = "O Login deve ter no máximo 20 caracteres")]
        [Display(Name = "Login")]
        public string  UserName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "o campo Senha é obrigatório")]
        [MaxLength(60, ErrorMessage = "A senha deve ter no máximo 60 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(12, ErrorMessage = "O telefone deve ter no máximo 12 caracteres")]
        [Display(Name = "Login")]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "o campo Email é obrigatório")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "o campo Permissão é obrigatório")]
        [Display(Name = "Permissão de usuário")]
        public byte IsAdmin { get; set; }

        [Display(Name = "Endereço")]
        public int EnderecoId { get; set; }

        public string UsuarioGuid { get; set; }

        public virtual Endereco Endereco { get; set; }




    }
}