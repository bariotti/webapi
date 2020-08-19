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
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
    }
}
