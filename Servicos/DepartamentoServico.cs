using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;
using Microsoft.EntityFrameworkCore;

namespace Udemy1.Servicos
{
    public class DepartamentoServico
    {
        private readonly TudoContext _context;

        public DepartamentoServico(TudoContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {

            // Trocar o ToList para o ToListAsync (EntityFrameWork)
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

        /* 
         * public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
        */

    }
}
