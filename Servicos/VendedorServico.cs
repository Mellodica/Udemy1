using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;

namespace Udemy1.Servicos
{
    public class VendedorServico
    {

        private readonly TudoContext _context;
           
        public VendedorServico(TudoContext context)
        {
            _context = context;
        }


        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
