using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy1.Servicos.Erros
{
    public class ErroDeIntegridade : ApplicationException
    {
        public ErroDeIntegridade(String message) : base(message)
        {

        }


    }
}
