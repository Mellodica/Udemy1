using System;


namespace Udemy1.Servicos.Erros
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(String message) : base(message)
        {

        }
    }
}
