using System;
using Udemy1.Models.Enums;
using Udemy1.Models.Enums;

namespace Udemy1.Models

{
    public class VendaGravada
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public VendaGravada()
        {

        }

        public VendaGravada(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
