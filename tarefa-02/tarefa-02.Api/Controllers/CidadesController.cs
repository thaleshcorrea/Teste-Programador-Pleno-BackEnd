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
using tarefa_02.Services;

namespace tarefa_02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly ICidadeService _cidadeService;

        public CidadesController(
            ICidadeRepository cidadeRepository,
            ICidadeService cidadeService)
        {
            _cidadeRepository = cidadeRepository;
            _cidadeService = cidadeService;

        }

        [HttpGet("{idEstado}")]
        [ProducesResponseType(typeof(GetCidadeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEstado(Guid idEstado)
        {
            return Ok(await _cidadeService.GetByEstado(idEstado));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<List<Cidade>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] CidadeFilter cidadeFilter)
        {
            return Ok(await _cidadeService.Get(cidadeFilter));
        }

        [HttpGet("exists/{idCidade}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Exists(Guid idCidade)
        {
            var response = await _cidadeService.Exists(idCidade);
            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCidadeDto addCidadeDto)
        {
            var response = await _cidadeService.Add(addCidadeDto);
            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCidadeDto updateCidadeDto)
        {
            var response = await _cidadeService.Update(updateCidadeDto);
            if (response.Succeeded)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}