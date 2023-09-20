using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Classes
{
    [Table("tbUsuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [NotMapped]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
