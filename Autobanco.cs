using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_progra
{
    class Autobanco
    {
        private List<Cuenta> cuentas = new List<Cuenta>();
        private List<Boveda> bovedas = new List<Boveda>();
        private int intentosPermitidos = 3;
        private int tipoDeCambio = 7;

        public Autobanco()
        {
            bovedas.Add(new Boveda("Quetzales", 50, 100)); // Bóveda de Q50
            bovedas.Add(new Boveda("Quetzales", 10, 200)); // Bóveda de Q10
            bovedas.Add(new Boveda("Quetzales", 1, 500));  // Bóveda de Q1
            bovedas.Add(new Boveda("Dólares", 1, 100));    // Bóveda de dólares
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("+++ AUTOBANCO +++");
                Console.WriteLine("1. Configuración de Parámetros");
                Console.WriteLine("2. Estaciones de Servicio");
                Console.WriteLine("3. Reportes");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConfigurarParametros();
                        break;
                    case "2":
                        EstacionesDeServicio();
                        break;
                    case "3":
                        MostrarReportes();
                        break;
                    case "4":
                        Environment.Exit(0); // Termina el programa
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ConfigurarParametros()
        {
            Console.Clear();
            Console.WriteLine("+++ CONFIGURACIÓN DE PARÁMETROS +++");
            Console.WriteLine("1. Intentos permitidos para ingreso de PIN");
            Console.WriteLine("2. Saldos en cada bóveda");
            Console.WriteLine("3. Tipo de cambio");
            Console.WriteLine("4. Configuración de cuentas");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConfigurarIntentos();
                    break;
                case "2":
                    ConfigurarBovedas();
                    break;
                case "3":
                    ConfigurarTipoDeCambio();
                    break;
                case "4":
                    ConfigurarCuentas();
                    break;
                case "5":
                    return; // Vuelve al menú principal
                default:
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void EstacionesDeServicio()
        {
            Console.Clear();
            Console.WriteLine("+++ ESTACIONES DE SERVICIO +++");
            Console.WriteLine("1. Compra/Venta de dólares");
            Console.WriteLine("2. Retiro");
            Console.WriteLine("3. Depósito");
            Console.WriteLine("4. Transferencia");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ComprarVenderDolares();
                    break;
                case "2":
                    RetirarDinero();
                    break;
                case "3":
                    DepositarDinero();
                    break;
                case "4":
                    TransferirDinero();
                    break;
                case "5":
                    return; // Vuelve al menú principal
                default:
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void MostrarReportes()
        {
            Console.Clear();
            Console.WriteLine("+++ REPORTES +++");
            Console.WriteLine("1. Saldo total por bóveda");
            Console.WriteLine("2. Saldo por bóveda y denominación");
            Console.WriteLine("3. Saldo por cuenta");
            Console.WriteLine("4. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarSaldoTotalBovedas();
                    break;
                case "2":
                    MostrarSaldoPorDenominacion();
                    break;
                case "3":
                    MostrarSaldoPorCuenta();
                    break;
                case "4":
                    return; // Vuelve al menú principal
                default:
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void ConfigurarIntentos()
        {
            Console.Write("Ingrese la cantidad de intentos permitidos para el PIN: ");
            if (int.TryParse(Console.ReadLine(), out int intentos) && intentos > 0)
            {
                intentosPermitidos = intentos;
                Console.WriteLine("Intentos configurados correctamente.");
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            Console.ReadLine();
        }

        private void ConfigurarBovedas()
        {
            foreach (var boveda in bovedas)
            {
                Console.WriteLine($"Bóveda: {boveda.TipoMoneda}, Denominación: {boveda.Denominacion}, Cantidad actual: {boveda.Cantidad}");
                Console.Write("Ingrese el nuevo saldo (múltiplo de la denominación): ");
                if (int.TryParse(Console.ReadLine(), out int nuevoSaldo) && nuevoSaldo % boveda.Denominacion == 0)
                {
                    boveda.Cantidad = nuevoSaldo / boveda.Denominacion;
                    Console.WriteLine("Bóveda actualizada correctamente.");
                }
                else
                {
                    Console.WriteLine("Saldo inválido. Debe ser múltiplo de la denominación.");
                }
            }
            Console.ReadLine();
        }

        private void ConfigurarTipoDeCambio()
        {
            Console.Write("Ingrese el tipo de cambio actual (Q por $): ");
            if (int.TryParse(Console.ReadLine(), out int cambio) && cambio > 0)
            {
                tipoDeCambio = cambio;
                Console.WriteLine("Tipo de cambio configurado correctamente.");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            Console.ReadLine();
        }

        private void ConfigurarCuentas()
        {
            if (cuentas.Count >= 3)
            {
                Console.WriteLine("Ya hay tres cuentas configuradas.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Console.Write("Ingrese el PIN: ");
            string pin = Console.ReadLine();

            Console.Write("Ingrese el saldo inicial: ");
            if (int.TryParse(Console.ReadLine(), out int saldoInicial) && saldoInicial > 0)
            {
                cuentas.Add(new Cuenta(numeroCuenta, pin, saldoInicial));
                Console.WriteLine("Cuenta configurada correctamente.");
            }
            else
            {
                Console.WriteLine("Saldo inválido.");
            }
            Console.ReadLine();
        }

        private void ComprarVenderDolares()
        {
            Console.WriteLine("+++ COMPRA/VENTA DE DÓLARES +++");
            Console.WriteLine("1. Comprar dólares");
            Console.WriteLine("2. Vender dólares");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ComprarDolares();
                    break;
                case "2":
                    VenderDolares();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void RetirarDinero()
        {
            Console.Write("Ingrese el número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Cuenta cuenta = cuentas.Find(c => c.NumeroCuenta == numeroCuenta);
            if (cuenta == null)
            {
                Console.WriteLine("Cuenta no encontrada.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el PIN: ");
            string pin = Console.ReadLine();
            if (!cuenta.ValidarPin(pin))
            {
                Console.WriteLine("PIN incorrecto.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el monto a retirar: ");
            if (int.TryParse(Console.ReadLine(), out int monto) && monto > 0)
            {
                if (cuenta.Retirar(monto))
                {
                    int montoRestante = monto;
                    foreach (var boveda in bovedas.FindAll(b => b.TipoMoneda == "Quetzales"))
                    {
                        int billetesNecesarios = montoRestante / boveda.Denominacion;
                        int billetesDisponibles = Math.Min(boveda.Cantidad, billetesNecesarios);
                        boveda.Cantidad -= billetesDisponibles;
                        montoRestante -= billetesDisponibles * boveda.Denominacion;
                    }

                    if (montoRestante > 0)
                    {
                        Console.WriteLine("No hay suficiente dinero en las bóvedas.");
                        cuenta.Depositar(monto);
                    }
                    else
                    {
                        Console.WriteLine($"Retiro completado exitosamente. Monto: Q{monto}");
                    }
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente en la cuenta.");
                }
            }
            else
            {
                Console.WriteLine("Monto inválido.");
            }
            Console.ReadLine();
        }

        private void DepositarDinero()
        {
            Console.Write("Ingrese el número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Cuenta cuenta = cuentas.Find(c => c.NumeroCuenta == numeroCuenta);
            if (cuenta == null)
            {
                Console.WriteLine("Cuenta no encontrada.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el monto a depositar: ");
            if (int.TryParse(Console.ReadLine(), out int monto) && monto > 0)
            {
                cuenta.Depositar(monto);

                var bovedaQuetzales = bovedas.Find(b => b.TipoMoneda == "Quetzales");
                bovedaQuetzales.Depositar(monto);

                Console.WriteLine($"Depósito completado exitosamente. Monto: Q{monto}");
            }
            else
            {
                Console.WriteLine("Monto inválido.");
            }
            Console.ReadLine();
        }

        private void TransferirDinero()
        {
            Console.Write("Ingrese el número de cuenta origen: ");
            string cuentaOrigen = Console.ReadLine();

            Cuenta origen = cuentas.Find(c => c.NumeroCuenta == cuentaOrigen);
            if (origen == null)
            {
                Console.WriteLine("Cuenta origen no encontrada.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el PIN de la cuenta origen: ");
            string pin = Console.ReadLine();
            if (!origen.ValidarPin(pin))
            {
                Console.WriteLine("PIN incorrecto.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el número de cuenta destino: ");
            string cuentaDestino = Console.ReadLine();
            Cuenta destino = cuentas.Find(c => c.NumeroCuenta == cuentaDestino);
            if (destino == null)
            {
                Console.WriteLine("Cuenta destino no encontrada.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el monto a transferir: ");
            if (int.TryParse(Console.ReadLine(), out int monto) && monto > 0 && origen.Retirar(monto))
            {
                destino.Depositar(monto);
                Console.WriteLine("Transferencia completada exitosamente.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente o monto inválido.");
            }
            Console.ReadLine();
        }

        private void MostrarSaldoTotalBovedas()
        {
            int total = 0;
            foreach (var boveda in bovedas)
            {
                total += boveda.Cantidad * boveda.Denominacion;
            }
            Console.WriteLine($"El saldo total en las bóvedas es: Q{total}");
            Console.ReadLine();
        }

        private void MostrarSaldoPorDenominacion()
        {
            Console.WriteLine("+++ SALDO POR BÓVEDA Y DENOMINACIÓN +++");
            foreach (var boveda in bovedas)
            {
                Console.WriteLine($"Bóveda: {boveda.TipoMoneda}, Denominación: Q{boveda.Denominacion}, Cantidad: {boveda.Cantidad}");
            }
            Console.ReadLine();
        }

        private void MostrarSaldoPorCuenta()
        {
            Console.WriteLine("+++ SALDO POR CUENTA +++");
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"Número de cuenta: {cuenta.NumeroCuenta}, Saldo: Q{cuenta.Saldo}");
            }
            Console.ReadLine();
        }

        private void ComprarDolares()
        {
            Console.Write("Ingrese la cantidad de dólares que desea comprar: ");
            if (int.TryParse(Console.ReadLine(), out int dolares) && dolares > 0)
            {
                int totalQuetzales = dolares * tipoDeCambio;

                var bovedaQuetzales = bovedas.Find(b => b.TipoMoneda == "Quetzales");
                var bovedaDolares = bovedas.Find(b => b.TipoMoneda == "Dólares");

                if (bovedaQuetzales != null && bovedaDolares != null && bovedaQuetzales.Retirar(totalQuetzales))
                {
                    bovedaDolares.Depositar(dolares);
                    Console.WriteLine($"Compra completada. Pagaste Q{totalQuetzales} por ${dolares}.");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes en las bóvedas.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            Console.ReadLine();
        }

        private void VenderDolares()
        {
            Console.Write("Ingrese la cantidad de dólares que desea vender: ");
            if (int.TryParse(Console.ReadLine(), out int dolares) && dolares > 0)
            {
                var bovedaDolares = bovedas.Find(b => b.TipoMoneda == "Dólares");

                if (bovedaDolares != null && bovedaDolares.Retirar(dolares))
                {
                    int totalQuetzales = dolares * tipoDeCambio;
                    var bovedaQuetzales = bovedas.Find(b => b.TipoMoneda == "Quetzales");
                    bovedaQuetzales.Depositar(totalQuetzales);
                    Console.WriteLine($"Venta completada. Recibiste Q{totalQuetzales} por ${dolares}.");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes en las bóvedas.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            Console.ReadLine();
        }
    }
}
