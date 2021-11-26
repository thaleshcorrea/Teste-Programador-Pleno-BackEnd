using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarefa_02.Dtos;
using tarefa_02.Filters;
using tarefa_02.HttpResponses;
using tarefa_02.Models;
using tarefa_02.Repositories;
using tarefa_02.Utils;

namespace tarefa_02.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public async Task<Response<Guid>> Add(AddCidadeDto addCidadeDto)
        {
            var results = ValidationUtils.Validate(addCidadeDto);
            if (results.Any())
            {
                var response = new Response<Guid>();
                response.Succeeded = false;
                response.Errors = results.Select(x => x.ErrorMessage).ToArray();
                return response;
            }

            Cidade cidade = new(addCidadeDto.CodigoIbge, addCidadeDto.NomeCidade, addCidadeDto.IdEstado);
            _cidadeRepository.Add(cidade);
            await _cidadeRepository.Save();
            return new Response<Guid>(cidade.IdCidade);
        }

        public async Task<Response<bool>> Exists(Guid idCidade)
        {
            if (await _cidadeRepository.Exists(idCidade))
                return new Response<bool>(true);
            else
            {
                return new Response<bool>
                {
                    Succeeded = false,
                    Data = false,
                    Errors = new string[] { "Cidade não encontrada" }
                };
            }
        }

        public async Task<PagedResponse<List<GetCidadeDto>>> Get(CidadeFilter filter)
        {
            var validFilter = new CidadeFilter(filter.IdEstado, filter.PageNumber, filter.PageSize);
            var cidades = await _cidadeRepository.Get(validFilter);
            var totalRecords = await _cidadeRepository.GetTotalRecords(validFilter.IdEstado);

            return new PagedResponse<List<GetCidadeDto>>(
                cidades, 
                validFilter.PageNumber, 
                validFilter.PageSize, 
                totalRecords);
        }

        public async Task<Response<List<GetCidadeDto>>> GetByEstado(Guid idEstado)
        {
            var cidades = await _cidadeRepository.GetByEstado(idEstado);
            return new Response<List<GetCidadeDto>>(cidades);
        }

        public async Task<Response<bool>> Update(UpdateCidadeDto updateCidadeDto)
        {
            var results = ValidationUtils.Validate(updateCidadeDto);
            if (results.Any())
            {
                var response = new Response<bool>
                {
                    Succeeded = false,
                    Errors = results.Select(x => x.ErrorMessage).ToArray()
                };
                return response;
            }

            Cidade cidade = await _cidadeRepository.GetById(updateCidadeDto.IdCidade);
            cidade.UpdateInfo(
                updateCidadeDto.CodigoIbge,
                updateCidadeDto.NomeCidade,
                updateCidadeDto.IdEstado
            );

            _cidadeRepository.Update(cidade);
            await _cidadeRepository.Save();
            return new Response<bool>(true);
        }
    }
}
