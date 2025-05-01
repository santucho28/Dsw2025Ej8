using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class Excepciones 

    {
        public class MontoNoValido : Exception
        {
            public MontoNoValido() : base("El monto debe ser Mayor a 0.") { }
        }
        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva() : base("La cuenta no se encuentra activa.") { }
        }

        public class SaldoInsuficiente : Exception
        {
            public SaldoInsuficiente() : base("Saldo insuficiente para realizar la operación.") { }
        }
    }
}
