namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string _numero { get; set; }
    public decimal _saldo { get; set; }
    public Estado _estado { get; set; }
    private string[] _titulares { get; set; }

    protected CuentaBancaria(string numero, decimal saldo, Estado estado, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = estado;
        _titulares = titulares;
    }

    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarInteres();
}
