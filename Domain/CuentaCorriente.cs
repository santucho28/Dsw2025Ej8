using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal _limiteDeDescubierto{  get; set; }
        private decimal _comision {  get; set; }

        public CuentaCorriente(string numero, decimal saldo, Estado estado, string[] titulares, decimal comision) : base (numero, saldo, estado, titulares)
        {
            _comision = comision;
        }
        public override void Depositar(decimal monto)
        {
            if(_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva();
            }
            if (monto <= 0)
            { 
                throw new Excepciones.MontoNoValido();
            }
            _saldo += monto - (monto * _comision);
        }

        public override void Retirar(decimal monto)
        {
            if (_estado != Estado.Activa)
            {
                throw new Excepciones.CuentaNoActiva();
            }
            if (monto <= 0) 
            { 
                throw new Excepciones.MontoNoValido();
            }
            if (_saldo - monto >= _limiteDeDescubierto)
            {
                _saldo = _saldo - monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
                throw new Excepciones.SaldoInsuficiente();
            }
        }
        public override void AplicarInteres()
        {
            
        }
    }
}
