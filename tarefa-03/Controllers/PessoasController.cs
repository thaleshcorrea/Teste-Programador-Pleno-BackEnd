using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tarefa_03.Dtos;
using tarefa_03.HttpResponse;
using tarefa_03.Models;
using tarefa_03.Repositories;
using tarefa_03.Services;

namespace tarefa_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICidadeService _cidadeService;
        public PessoasController(IPessoaRepository pessoaRepository, ICidadeService cidadeService)
        {
            _pessoaRepository = pessoaRepository;
            _cidadeService = cidadeService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<IActionResult> Add(AddPessoaDto addPessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _cidadeService.Exists(addPessoaDto.IdCidade))
                return BadRequest(new ErrorResponse("A cidade informada não existe."));

            Pessoa pessoa = new(
                addPessoaDto.Nome,
                addPessoaDto.Cpf,
                addPessoaDto.IdCidade,
                addPessoaDto.IdEstado);
            _pessoaRepository.Add(pessoa);
            await _pessoaRepository.Save();

            return Ok(pessoa.IdPessoa);
        }
    }
}
