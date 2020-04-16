using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;

namespace Udemy1.Servicos
{
    public class DepartamentoServico
    {
        private readonly TudoContext _context;

        public DepartamentoServico(TudoContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }

    }
}
