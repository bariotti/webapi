using WebApi.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class PessoaDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "Tamanho limite é 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [MinLength(0)]
        [MaxLength(99)]
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
    }
}
