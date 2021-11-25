using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tarefa_02.Data;
using tarefa_02.Dtos;
using tarefa_02.Filters;
using tarefa_02.Models;

namespace tarefa_02.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly DataContext _context;
        public CidadeRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Cidade cidade)
        {
            _context.Cidade.Add(cidade);
        }

        public async Task<bool> Exists(Guid idCidade)
        {
            return await _context.Cidade.AnyAsync(x => x.IdCidade == idCidade);
        }

        public async Task<List<GetCidadeDto>> Get(PaginationFilter filter)
        {
            return await _context.Cidade.AsNoTracking()
                .Skip((filter.PageNumber - 1) * filter.PageNumber)
                .Take(filter.PageSize)
                .Select(x => new GetCidadeDto
                {
                    IdCidade = x.IdCidade,
                    CodigoIbge = x.CodigoIbge,
                    NomeCidade = x.NomeCidade
                })
                .ToListAsync();
        }

        public async Task<List<GetCidadeDto>> GetByEstado(Guid idEstado)
        {
            return await _context.Cidade.AsNoTracking()
                .Where(x => x.IdEstado == idEstado)
                .Select(x => new GetCidadeDto
                {
                    IdCidade = x.IdCidade,
                    CodigoIbge = x.CodigoIbge,
                    NomeCidade = x.NomeCidade
                })
                .ToListAsync();
        }

        public async Task<Cidade> GetById(Guid idCidade)
        {
            return await _context.Cidade.AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdCidade == idCidade);
        }

        public async Task<int> GetTotalRecords(Guid idEstado)
        {
            return await _context.Cidade.CountAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Cidade cidade)
        {
            throw new NotImplementedException();
        }
    }
}