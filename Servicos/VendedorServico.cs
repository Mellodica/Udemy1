using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;
using Microsoft.EntityFrameworkCore;
using Udemy1.Servicos.Erros;

namespace Udemy1.Servicos
{
    public class VendedorServico
    {

        private readonly TudoContext _context;
           
        public VendedorServico(TudoContext context)
        {
            _context = context;
        }


        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int id)
        {

            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj =  await _context.Vendedor.FindAsync(id);
                        _context.Vendedor.Remove(obj);
                       await _context.SaveChangesAsync(); 
        }

        public async Task AtualizarAsync(Vendedor obj)
        {
            //Antigo  if (!_context.Vendedor.Any(x => x.Id == obj.Id))

            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrada");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
                 
            }
          
        }

    }
}
