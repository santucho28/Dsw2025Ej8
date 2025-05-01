using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        public decimal _tasaDeInteres { get; set; }

        public CajaDeAhorro(string numero, decimal saldo, Estado estado, string[] titulares) : base(numero, saldo, estado, titulares) 
        {
           
        }

        public override void Depositar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva();
            }
            if (monto <= 0)
            { 
                throw new Excepciones.MontoNoValido();
            }
            _saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva();
            }
            if (_saldo <= 0)
            {
                _estado = Estado.Suspendida;
                throw new Excepciones.SaldoInsuficiente();
            }
            _saldo -= monto;
        }

        public override void AplicarInteres()
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva();
            }
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
