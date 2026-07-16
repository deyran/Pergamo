using System;

using PFlow_Database.Administrativo.Entities;
using PFlow_Domain.Administrativo.Entities;
using PFlow_Domain.Administrativo.Interfaces;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PFlow_Database.Administrativo.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PFlowContext _context;

        public PessoaRepository(PFlowContext context) => _context = context;

        public async Task<IEnumerable<Pessoa>> GetAllAsync() =>
            await _context.Pessoas.Select(p => new Pessoa
            {
                IdPessoa = p.IdPessoa,
                Nome = p.Nome,
                RG = p.RG,
                CPF = p.CPF,
                Sexo = p.Sexo,
                DataNasc = p.DataNasc,
                Naturalidade = p.Naturalidade,
                EstadoCivil = p.EstadoCivil
            }).ToListAsync();

        public async Task<Pessoa> GetByIdAsync(int id) =>
            await _context.Pessoas
                .Where(p => p.IdPessoa == id)
                .Select(p => new Pessoa
                {
                    IdPessoa = p.IdPessoa,
                    Nome = p.Nome,
                    RG = p.RG,
                    CPF = p.CPF,
                    Sexo = p.Sexo,
                    DataNasc = p.DataNasc,
                    Naturalidade = p.Naturalidade,
                    EstadoCivil = p.EstadoCivil
                })
                .FirstOrDefaultAsync();
        public async Task AddAsync(Pessoa pessoa)
        {
            var entity = new PessoaDB
            {
                IdPessoa = GetNextId(),
                Nome = pessoa.Nome,
                RG = pessoa.RG,
                CPF = pessoa.CPF,
                Sexo = pessoa.Sexo,
                DataNasc = pessoa.DataNasc,
                Naturalidade = pessoa.Naturalidade,
                EstadoCivil = pessoa.EstadoCivil
            };

            _context.Pessoas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pessoa pessoa)
        {
            var entity = await _context.Pessoas.FindAsync(pessoa.IdPessoa);
            // Atualizar campos da entidade com dados de 'pessoa'
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(entity);
            await _context.SaveChangesAsync();
        }

        private int GetNextId() =>
            _context.Pessoas.Any() ? _context.Pessoas.Max(p => p.IdPessoa) + 1 : 1;
    }
}