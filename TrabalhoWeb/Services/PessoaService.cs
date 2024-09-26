using Dapper;
using System.Data.SqlClient;
using TrabalhoWeb.Models;

namespace TrabalhoWeb.Services
{
    public class PessoaService : IPessoaInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;


        public PessoaService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection  = _configuration.GetConnectionString("DefaultConnection");
        }

        public  async Task<IEnumerable<Localidades>> GetAllPessoas()
        {
            //Abrindo conexão com banco
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Localidades";
                return await con.QueryAsync<Localidades>(sql);
            }

        }
        public async Task<IEnumerable<Pessoa>> CreatePessoa(Pessoa pessoa)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "INSERT INTO Pessoa (Nome, Sobrenome, CPF, CNS, DataNascimento, Endereco, Bairro, Cidade, CEP, Complemento) VALUES (@Nome, @Sobrenome, @CPF, @CNS, @DataNascimento, @Endereco, @Bairro, @Cidade, @CEP, @Complemento)";
                await con.ExecuteAsync(sql, pessoa);
               
                return await con.QueryAsync<Pessoa>("select * from Pessoa");
            }
        }

        public Task<Pessoa> GetPessoaById()
        {
            throw new NotImplementedException();
        }
    }
}
