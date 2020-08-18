using WebApi.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Base.Repository
{
    public interface IPessoaRepository
    {
        Pessoa Adicionar(Pessoa pessoa);
        Pessoa Editar(Pessoa pessoa);
        void Deletar(Pessoa pessoa);
        Pessoa Get(string cpf);
        IEnumerable<Pessoa> Get(bool incluirInativo);
    }
}
