using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoWeb.Models;
using TrabalhoWeb.Services;

namespace TrabalhoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaControler : ControllerBase
    {
        private readonly IPessoaInterface _pessoaInterface;
        public PessoaControler(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaService>>> GetAllPessoas()
        {
            IEnumerable<Pessoa> pessoa = await _pessoaInterface.GetAllPessoas();

            if (pessoa == null)
                return NotFound("Nenhum registro encontrado");


            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Pessoa>>> CreatePessoa(Pessoa pessoa)
        {
            IEnumerable<Pessoa> pessoas = await _pessoaInterface.CreatePessoa(pessoa);
            return Ok(pessoas);

        }
    }
}
