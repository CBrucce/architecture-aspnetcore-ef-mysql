using ArchitectureAspNetCoreEFMySQL.Core.Data;
using ArchitectureAspNetCoreEFMySQL.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectureAspNetCoreEFMySQL.Core.Business
{
    public class Carro : ICarros
    {
        private readonly AppDbContext _context;

        public Carro(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método assíncrono para recuperar todos os carros que existe do banco de dados.
        /// </summary>
        /// <returns> Retorna a coleção de carros. </returns>
        public async Task<IEnumerable<Domain.Entities.Carro>> GetAllAsync()
        {
            try
            {
                IEnumerable<Domain.Entities.Carro> carros = await _context.Carros.ToListAsync();
                return carros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para retornar um carro.
        /// </summary>
        /// <param name="id"> Recebe a ID do carro que queremos buscar no banco. </param>
        /// <returns> Retorna o objeto do carro. </returns>
        public async Task<Domain.Entities.Carro> GetByIdAsync(int? id)
        {
            try
            {
                Domain.Entities.Carro carro = await _context.Carros.FirstOrDefaultAsync(c => c.Id == id);
                return carro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para adicionar um novo carro no banco de dados.
        /// </summary>
        /// <param name="carro"> Recebe o objeto carro que será adicionado no banco. </param>
        public async Task Add(Domain.Entities.Carro carro)
        {
            _context.Add(carro);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método para editar um carro no banco de dados.
        /// </summary>
        /// <param name="carro"> Recebe o objeto carro com as propriedades editadas (ou não). </param>
        public async Task Edit(Domain.Entities.Carro carro)
        {
            _context.Update(carro);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método para deletar um carro do banco de dados.
        /// </summary>
        /// <param name="id"> Recebe a ID do objeto que será excluído. </param>
        public async Task Delete(int id)
        {
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carros.Remove(carro);
            
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método auxiliar para verificar se um carro existe na base de dados.
        /// </summary>
        /// <param name="id"> Recebe a ID do objeto carro. </param>
        /// <returns> Retorna um valor boolean informando a existência do carro. </returns>
        public bool Exists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
