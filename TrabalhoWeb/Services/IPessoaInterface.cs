using TrabalhoWeb.Models;

namespace TrabalhoWeb.Services
{
    public interface IPessoaInterface
    {
        Task<IEnumerable<Pessoa>> GetAllPessoas();
        Task<Pessoa> GetPessoaById();

        Task<IEnumerable<Pessoa>> CreatePessoa(Pessoa pessoa);

    }
}
