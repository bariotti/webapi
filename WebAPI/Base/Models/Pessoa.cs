using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Base.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
    }

    public class Contato
    {
        public string Descricao { get; set; }
        public TIPO_CONTATO Tipo { get; set; }
    }

    public enum TIPO_CONTATO
    { 
        TELEFONE_FIXO, CELULAR, EMAIL
    }

}
