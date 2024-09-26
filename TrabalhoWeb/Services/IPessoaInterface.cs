using TrabalhoWeb.Models;

namespace TrabalhoWeb.Services
{
    public interface IPessoaInterface
    {
        Task<IEnumerable<Localidades>> GetAllPessoas();

        Task<Pessoa> GetPessoaById();

        Task<IEnumerable<Pessoa>> CreatePessoa(Pessoa pessoa);

    }
}
