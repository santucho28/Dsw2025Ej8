using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ca1 = new CajaDeAhorro("CA001", 1000m, Estado.Activa, new string[] { "Juan", "Pablo" });
            var ca2 = new CajaDeAhorro("CA002", 500m, Estado.Activa, new string[] { "Manuel" });
            var cc1 = new CuentaCorriente("CC001", 800m, Estado.Activa, new string[] { "Javier" }, 0.05m);
            var cc2 = new CuentaCorriente("CC002", 200m, Estado.Activa, new string[] { "Manolo", "Martin" }, 0.02m);
           
            ca1._tasaDeInteres = 0.10m;
            ca2._tasaDeInteres = 0.05m;
            cc1._limiteDeDescubierto = -200m;
            cc2._limiteDeDescubierto = -100m;

            var cuentas = new List<CuentaBancaria> { ca1, ca2, cc1, cc2};

            try
            {
                ca1.Depositar(500m);
                Console.WriteLine("ca1 Depósito exitoso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ca1 Excepción en depósito: {ex.Message}");
            }

            try
            {
                ca1.Retirar(300m);
                Console.WriteLine("ca1 Retiro exitoso.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"ca1 Excepción en retiro: {ex.Message}");
            }

            try
            {
                ca1.AplicarInteres();
                Console.WriteLine("ca1 Interés aplicado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ca1 Excepción en aplicar interés: {ex.Message}");
            }

            
            try
            {
                cc1.Depositar(1000m);
                Console.WriteLine("cc1 Depósito con comisión exitoso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"cc1 Excepción en depósito: {ex.Message}");
            }


            try
            {
                cc1.Retirar(1800m);
                Console.WriteLine("cc1 Retiro exitoso dentro del descubierto.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"cc1 Excepción en retiro: {ex.Message}");
            }

            try
            {
                cc1.Depositar(1000m);
                Console.WriteLine("cc1 Depósito con comisión exitoso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"cc1 Excepción en depósito: {ex.Message}");
            }

            try
            {
                ca1.Depositar(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ca1 Excepción en depósito con monto cero: {ex.Message}");
            }

            try
            {
                ca1.Retirar(-50);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ca1 Excepción en retiro con monto negativo: {ex.Message}");
            }

            Console.WriteLine("\n--- Resumen de cuentas ---");
            foreach (var cuenta in cuentas)
            {
                var c = new
                {
                    Numero = cuenta._numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta._saldo,
                    Estado = cuenta._estado
                };
                Console.WriteLine($"Numero: {c.Numero}, Tipo {c.Tipo}, Saldo: ${c.Saldo}, Estado: {c.Estado}");
            }

        }
    }
}
