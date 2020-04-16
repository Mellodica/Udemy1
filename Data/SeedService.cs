using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy1.Models;
using Udemy1.Models.Enums;
namespace Udemy1.Data
{
    public class SeedService
    {
        private TudoContext _context;

        public SeedService(TudoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.VendaGravadas.Any())
            {
                return; // Banco de Dados já Populado!
            }

            Departamento d1 = new Departamento(new int(), "Computadores");
            Departamento d2 = new Departamento(new int(), "Eletronicos");
            Departamento d3 = new Departamento(new int(), "Moda");
            Departamento d4 = new Departamento(new int(), "Livros");
            Departamento d5 = new Departamento(new int(), "Porno" );


            Vendedor v1 = new Vendedor(new int(), "Jane Doo", "jane@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(new int(), "Bob Brow", "bob@gmail.com", new DateTime(1995, 7, 25), 1400.0, d2);
            Vendedor v3 = new Vendedor(new int(), "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 1200.0, d5);
            
            Vendedor v4 = new Vendedor(new int(), "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor v5 = new Vendedor(new int(), "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor v6 = new Vendedor(new int(), "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d5);



            VendaGravada r1 = new VendaGravada(new int(), new DateTime(2018, 09, 25), 11000.0, StatusVenda.Faturado, v1);
            VendaGravada r2 = new VendaGravada(new int(), new DateTime(2018, 09, 4), 7000.0, StatusVenda.Faturado, v5);
            VendaGravada r3 = new VendaGravada(new int(), new DateTime(2018, 09, 13), 4000.0, StatusVenda.Cancelado, v4);
            VendaGravada r4 = new VendaGravada(new int(), new DateTime(2018, 09, 1), 8000.0, StatusVenda.Faturado, v1);
            VendaGravada r5 = new VendaGravada(new int(), new DateTime(2018, 09, 21), 3000.0, StatusVenda.Faturado, v3);
            VendaGravada r6 = new VendaGravada(new int(), new DateTime(2018, 09, 15), 2000.0, StatusVenda.Faturado, v1);
            VendaGravada r7 = new VendaGravada(new int(), new DateTime(2018, 09, 28), 13000.0, StatusVenda.Faturado, v2);
            VendaGravada r8 = new VendaGravada(new int(), new DateTime(2018, 09, 11), 4000.0, StatusVenda.Faturado, v4);
            VendaGravada r9 = new VendaGravada(new int(), new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, v6);
            VendaGravada r10 = new VendaGravada(new int(), new DateTime(2018, 09, 7), 9000.0, StatusVenda.Faturado, v6);
            VendaGravada r11 = new VendaGravada(new int(), new DateTime(2018, 09, 13), 6000.0, StatusVenda.Faturado, v2);
            VendaGravada r12 = new VendaGravada(new int(), new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, v3);
            VendaGravada r13 = new VendaGravada(new int(), new DateTime(2018, 09, 29), 10000.0, StatusVenda.Faturado, v4);
            VendaGravada r14 = new VendaGravada(new int(), new DateTime(2018, 09, 4), 3000.0, StatusVenda.Faturado, v5);
            VendaGravada r15 = new VendaGravada(new int(), new DateTime(2018, 09, 12), 4000.0, StatusVenda.Faturado, v1);
            VendaGravada r16 = new VendaGravada(new int(), new DateTime(2018, 10, 5), 2000.0, StatusVenda.Faturado, v4);
            VendaGravada r17 = new VendaGravada(new int(), new DateTime(2018, 10, 1), 12000.0, StatusVenda.Faturado, v1);
            VendaGravada r18 = new VendaGravada(new int(), new DateTime(2018, 10, 24), 6000.0, StatusVenda.Faturado, v3);
            VendaGravada r19 = new VendaGravada(new int(), new DateTime(2018, 10, 22), 8000.0, StatusVenda.Faturado, v5);
            VendaGravada r20 = new VendaGravada(new int(), new DateTime(2018, 10, 15), 8000.0, StatusVenda.Faturado, v6);
            VendaGravada r21 = new VendaGravada(new int(), new DateTime(2018, 10, 17), 9000.0, StatusVenda.Faturado, v2);
            VendaGravada r22 = new VendaGravada(new int(), new DateTime(2018, 10, 24), 4000.0, StatusVenda.Faturado, v4);
            VendaGravada r23 = new VendaGravada(new int(), new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, v2);
            VendaGravada r24 = new VendaGravada(new int(), new DateTime(2018, 10, 12), 8000.0, StatusVenda.Faturado, v5);
            VendaGravada r25 = new VendaGravada(new int(), new DateTime(2018, 10, 31), 7000.0, StatusVenda.Faturado, v3);
            VendaGravada r26 = new VendaGravada(new int(), new DateTime(2018, 10, 6), 5000.0, StatusVenda.Faturado, v4);
            VendaGravada r27 = new VendaGravada(new int(), new DateTime(2018, 10, 13), 9000.0, StatusVenda.Pendente, v1);
            VendaGravada r28 = new VendaGravada(new int(), new DateTime(2018, 10, 7), 4000.0, StatusVenda.Faturado, v3);
            VendaGravada r29 = new VendaGravada(new int(), new DateTime(2018, 10, 23), 12000.0, StatusVenda.Faturado, v5);
            VendaGravada r30 = new VendaGravada(new int(), new DateTime(2018, 10, 12), 5000.0, StatusVenda.Faturado, v2);


            _context.Departamento.AddRange(d1, d2, d3, d4, d5);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.VendaGravadas.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22,
                r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges();

        }

    }
}
