using System;


namespace Udemy1.Servicos.Erros
{
    public class NotFoundException : ApplicationException
    {

        public NotFoundException(String message) : base(message)
        {

        }

    }
}
