using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy1.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]      //Nome paga com chave zero {0}, Maximo com chave 1 e minimo chave 2
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "{0} Entre com um E-mail válido")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Aniversario { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve estar entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        public Departamento Departamento { get; set; }


        
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public ICollection<VendaGravada> Vendas { get; set; } = new List<VendaGravada>();


        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double baseSalary, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            BaseSalary = baseSalary;
            Departamento = departamento;
        }

        public void AddVenda(VendaGravada vg)
        {
            Vendas.Add(vg);
        }

        public void RemoVenda(VendaGravada rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Where(vg => vg.Data >= inicio && vg.Data <= final).Sum(vg => vg.Valor);
        }

    }
}
