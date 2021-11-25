using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tarefa_02.Dtos;
using tarefa_02.Filters;
using tarefa_02.HttpResponses;
using tarefa_02.Models;
using tarefa_02.Repositories;

namespace tarefa_02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadesController(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [HttpGet("{idEstado}")]
        [ProducesResponseType(typeof(GetCidadeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEstado(Guid idEstado)
        {
            return Ok(await _cidadeRepository.GetByEstado(idEstado));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<Cidade>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] CidadeFilter cidadeFilter)
        {
            var filter = new PaginationFilter(cidadeFilter.PageNumber, cidadeFilter.PageSize);
            var cidades = await _cidadeRepository.Get(filter);
            var totalRecords = await _cidadeRepository.GetTotalRecords(new Guid());
            return Ok(new PagedResponse<List<GetCidadeDto>>(cidades, filter.PageNumber, filter.PageSize));
        }

        [HttpGet("exists/{idCidade}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Exists(Guid idCidade)
        {
            if (await _cidadeRepository.Exists(idCidade))
                return Ok(new Response<bool>(true));
            else
            {
                var response = new Response<bool>();
                response.Succeeded = false;
                response.Data = false;
                response.Errors = new string[] { "Cidade não encontrada" };
                return BadRequest(response);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCidadeDto addCidadeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Cidade cidade = new(addCidadeDto.CodigoIbge, addCidadeDto.NomeCidade, addCidadeDto.IdEstado);

            _cidadeRepository.Add(cidade);
            await _cidadeRepository.Save();
            return Ok(new Response<Guid>(cidade.IdCidade));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCidadeDto updateCidadeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Cidade cidade = await _cidadeRepository.GetById(updateCidadeDto.IdCidade);
            cidade.UpdateInfo(
                updateCidadeDto.CodigoIbge,
                updateCidadeDto.NomeCidade,
                updateCidadeDto.IdEstado
            );

            _cidadeRepository.Update(cidade);
            await _cidadeRepository.Save();
            return NoContent();
        }
    }
}