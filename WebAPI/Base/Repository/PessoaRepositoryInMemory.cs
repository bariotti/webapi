using WebApi.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Base.Repository
{
    public class PessoaRepositoryInMemory : IPessoaRepository
    {
        private IList<Pessoa> pessoas;

        public PessoaRepositoryInMemory()
        {
            pessoas = new List<Pessoa>();
            Seed();
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            if (pessoas.Any())
                pessoa.Id = pessoas.Max(p => p.Id) + 1;
            else
                pessoa.Id = 1;

            pessoas.Add(pessoa);
            return pessoa;
        }

        public void Deletar(Pessoa pessoa)
        {
            pessoas.Remove(pessoa);
        }

        public Pessoa Editar(Pessoa pessoa)
        {
            var pessoaToUpdated = pessoas.Where(p => p.Id == pessoa.Id).First();
            int index = pessoas.IndexOf(pessoaToUpdated);
            pessoas[index] = pessoa;
            return pessoa;
        }

        public IEnumerable<Pessoa> Get(bool incluirInativo = false)
        {
            if (incluirInativo == true)
                return pessoas;
            else
                return pessoas.Where(p => p.Ativo == true);
        }

        public Pessoa Get(string cpf)
        {
            return pessoas.Where(p => p.Cpf == cpf).FirstOrDefault();
        }

        private void Seed()
        {
            //Add João
            var contatoJoao1 = new Contato
            {
                Tipo = TIPO_CONTATO.EMAIL,
                Descricao = "joao@gmail.com"
            };

            var contatoJoao2 = new Contato
            {
                Tipo = TIPO_CONTATO.CELULAR,
                Descricao = "11 9 1111-1111"
            };

            var contatosJoao = new List<Contato>();
            contatosJoao.Add(contatoJoao1);
            contatosJoao.Add(contatoJoao2);

            var pessoaJoao = new Pessoa()
            {
                Nome = "João",
                Cpf = "111.111.111-11",
                Ativo = true,
                Idade = 50,
                Contatos = contatosJoao
            };

            Adicionar(pessoaJoao);

            //Add Maria
            var contatoMaria = new Contato
            {
                Tipo = TIPO_CONTATO.EMAIL,
                Descricao = "maria@gmail.com"
            };

            var contatosMaria = new List<Contato>();
            contatosMaria.Add(contatoMaria);

            var pessoaMaria = new Pessoa()
            {
                Nome = "Maria",
                Cpf = "222.222.222-22",
                Ativo = false,
                Idade = 30,
                Contatos = contatosMaria
            };

            Adicionar(pessoaMaria);

            //Add José
            
            var pessoaJose = new Pessoa()
            {
                Nome = "José",
                Cpf = "333.333.333-33",
                Idade = 18,
                Ativo = true,
            };

            Adicionar(pessoaJose);
        }
    }
}
