using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;

namespace Udemy1.Servicos
{
    public class VendaGravadaServico
    {

        private readonly TudoContext _context;

        public VendaGravadaServico(TudoContext context)
        {
            _context = context;
        }

        public async Task<List<VendaGravada>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {

            var result = from obj in _context.VendaGravadas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
                
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            return await result
                            .Include(x => x.Vendedor)
                            .Include(x => x.Vendedor.Departamento)
                            .OrderByDescending(x => x.Data)
                            .ToListAsync();

        }

    }
}
