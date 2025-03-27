using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


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
                Console.WriteLine("*** AutoBanco ***\n");
                Console.WriteLine("1. Configuración de Parámetros");
                Console.WriteLine("2. Estaciones de Servicio");
                Console.WriteLine("3. Reportes");
                Console.WriteLine("4. Gestión de Cuentas");
                Console.WriteLine("5. Salir");
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
                        GestionCuentas();
                        break;
                    case "5":
                        GuardarDatos(); // Guarda bóvedas y cuentas antes de salir
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ConfigurarParametros()
        {
            Console.Clear();
            Console.WriteLine("*** Configuración de parámetros ***\n");
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
                    Console.Clear();
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void EstacionesDeServicio()
        {
            Console.Clear();
            Console.WriteLine("*** Estaciones de Servicio ***\n");
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
                    return; 
                default:
                    Console.Clear();
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void MostrarReportes()
        {
            Console.Clear();
            Console.WriteLine("*** Reportes ***\n");
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
                    return; 
                default:

                    Console.Clear();
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void ConfigurarIntentos()
        {
            Console.Clear();
            Console.Write("Ingrese la cantidad de intentos permitidos para el PIN: ");
            if (int.TryParse(Console.ReadLine(), out int intentos) && intentos > 0)
            {
                intentosPermitidos = intentos;
                Console.WriteLine("Intentos configurados correctamente.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cantidad inválida.");
            }
            Console.ReadLine();
        }

        private void ConfigurarBovedas()
        {
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.WriteLine("*** Compra / venta de dólares ***\n");
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
                    Console.Clear();
                    Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                    Console.ReadLine();
                    break;
            }
        }

        private void RetirarDinero()
        {
            Console.Clear();
            Console.Write("Ingrese el número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Cuenta cuenta = cuentas.Find(c => c.NumeroCuenta == numeroCuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.WriteLine("Cuenta no encontrada.");
                Console.ReadLine();
                return;
            }

            Console.Write("Ingrese el PIN: ");
            string pin = Console.ReadLine();
            if (!cuenta.ValidarPin(pin))
            {
                Console.Clear();
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

                    foreach (var boveda in bovedas.FindAll(b => b.TipoMoneda == "Quetzales").OrderByDescending(b => b.Denominacion))
                    {
                        int billetesNecesarios = montoRestante / boveda.Denominacion;
                        int billetesDisponibles = Math.Min(boveda.Cantidad, billetesNecesarios);

                        boveda.Cantidad -= billetesDisponibles;
                        montoRestante -= billetesDisponibles * boveda.Denominacion;

                        if (montoRestante == 0)
                        {
                            break;
                        }
                    }

                    if (montoRestante > 0)
                    {
                        Console.WriteLine("No hay suficiente dinero en las bóvedas para completar el retiro.");
                        cuenta.Depositar(monto); 
                    }
                    else
                    {
                        Console.WriteLine($"Retiro completado exitosamente. Monto: Q{monto}");
                        GuardarBovedas(); 
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

                int montoRestante = monto;

                foreach (var boveda in bovedas.FindAll(b => b.TipoMoneda == "Quetzales").OrderByDescending(b => b.Denominacion))
                {
                    int billetesAAgregar = montoRestante / boveda.Denominacion;
                    boveda.Cantidad += billetesAAgregar;
                    montoRestante -= billetesAAgregar * boveda.Denominacion;
                }

                GuardarBovedas(); 

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
            if (bovedas == null || !bovedas.Any())
            {
                Console.WriteLine("No hay datos disponibles en las bóvedas.");
                return;
            }

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
                if (boveda.Cantidad < 0)
                {
                    Console.WriteLine($"ERROR: Bóveda {boveda.Denominacion} tiene un saldo negativo.");
                }
                else
                {
                    Console.WriteLine($"Bóveda: {boveda.TipoMoneda}, Denominación: Q{boveda.Denominacion}, Cantidad: {boveda.Cantidad}");
                }
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

                var bovedasQuetzales = bovedas.FindAll(b => b.TipoMoneda == "Quetzales").OrderByDescending(b => b.Denominacion);
                var bovedaDolares = bovedas.Find(b => b.TipoMoneda == "Dólares");

                if (bovedasQuetzales != null && bovedaDolares != null)
                {
                    int montoRestante = totalQuetzales;

                    foreach (var boveda in bovedasQuetzales)
                    {
                        int billetesNecesarios = montoRestante / boveda.Denominacion;
                        int billetesDisponibles = Math.Min(boveda.Cantidad, billetesNecesarios);

                        boveda.Cantidad -= billetesDisponibles;
                        montoRestante -= billetesDisponibles * boveda.Denominacion;

                        if (montoRestante == 0)
                        {
                            break;
                        }
                    }

                    if (montoRestante > 0)
                    {
                        Console.WriteLine("No hay suficientes fondos en las bóvedas para completar la compra.");
                        return;
                    }

                    
                    bovedaDolares.Depositar(dolares);
                    Console.WriteLine($"Compra completada. Pagaste Q{totalQuetzales} por ${dolares}.");
                }
                else
                {
                    Console.WriteLine("Error al localizar las bóvedas. Por favor verifica la configuración.");
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

                if (bovedaDolares != null)
                {
                    if (bovedaDolares.Retirar(dolares))
                    {
                        int totalQuetzales = dolares * tipoDeCambio;
                        var bovedaQuetzales = bovedas.Find(b => b.TipoMoneda == "Quetzales");
                        if (bovedaQuetzales != null)
                        {
                            bovedaQuetzales.Depositar(totalQuetzales);
                            Console.WriteLine($"Venta completada. Recibiste Q{totalQuetzales} por ${dolares}.");
                        }
                        else
                        {
                            Console.WriteLine("Error al localizar la bóveda de quetzales.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fondos insuficientes en la bóveda de dólares para completar la venta.");
                    }
                }
                else
                {
                    Console.WriteLine("Error al localizar la bóveda de dólares.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad inválida.");
            }
            Console.ReadLine();
        }

        private void GestionCuentas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Gestión de cuentas ***\n");
                Console.WriteLine("1. Ver cuentas");
                Console.WriteLine("2. Editar cuenta");
                Console.WriteLine("3. Eliminar cuenta");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        VerCuentas();
                        break;
                    case "2":
                        EditarCuenta();
                        break;
                    case "3":
                        EliminarCuenta();
                        break;
                    case "4":
                        return; 
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void VerCuentas()
        {
            Console.Clear();
            Console.WriteLine("*** Lista de Cuentas ***\n");

            if (cuentas.Count == 0)
            {
                Console.WriteLine("No hay cuentas configuradas.");
            }
            else
            {
                foreach (var cuenta in cuentas)
                {
                    Console.WriteLine($"Número: {cuenta.NumeroCuenta}, Saldo: Q{cuenta.Saldo}");
                }
            }

            Console.WriteLine("Presione ENTER para regresar.");
            Console.ReadLine();
        }

        private void EditarCuenta()
        {
            Console.Clear();
            Console.WriteLine("*** Editar cuentas *** \n");

            Console.Write("Ingrese el número de cuenta a editar: ");
            string numeroCuenta = Console.ReadLine();
            var cuenta = cuentas.Find(c => c.NumeroCuenta == numeroCuenta);

            if (cuenta == null)
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                Console.WriteLine($"Cuenta encontrada: Número: {cuenta.NumeroCuenta}, Saldo: Q{cuenta.Saldo}");
                Console.Write("Ingrese el nuevo PIN (deje vacío para no cambiar): ");
                string nuevoPin = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoPin))
                {
                    cuenta.Pin = nuevoPin;
                }

                Console.Write("Ingrese el nuevo saldo (deje vacío para no cambiar): ");
                string nuevoSaldoStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoSaldoStr) && int.TryParse(nuevoSaldoStr, out int nuevoSaldo))
                {
                    cuenta.Saldo = nuevoSaldo;
                }

                Console.WriteLine("Cuenta actualizada.");
            }

            Console.WriteLine("Presione ENTER para regresar.");
            Console.ReadLine();
        }

        private void EliminarCuenta()
        {
            Console.Clear();
            Console.WriteLine("*** Eliminar algúna cuenta ***\n");

            Console.Write("Ingrese el número de cuenta a eliminar: ");
            string numeroCuenta = Console.ReadLine();
            var cuenta = cuentas.Find(c => c.NumeroCuenta == numeroCuenta);

            if (cuenta == null)
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                cuentas.Remove(cuenta);
                Console.WriteLine("Cuenta eliminada.");
            }

            Console.WriteLine("Presione ENTER para regresar.");
            Console.ReadLine();
        }

        public void GuardarCuentas()
        {
            string jsonCuentas = JsonSerializer.Serialize(cuentas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("cuentas.json", jsonCuentas);
        }

        public void CargarCuentas()
        {
            if (File.Exists("cuentas.json"))
            {
                string jsonCuentas = File.ReadAllText("cuentas.json");
                cuentas = JsonSerializer.Deserialize<List<Cuenta>>(jsonCuentas) ?? new List<Cuenta>();
            }
        }

        public void GuardarDatos()
        {
            
            string jsonCuentas = JsonSerializer.Serialize(cuentas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("cuentas.json", jsonCuentas);

            
            string jsonBovedas = JsonSerializer.Serialize(bovedas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("bovedas.json", jsonBovedas);

            Console.WriteLine("Datos guardados exitosamente.");
        }

        public void CargarDatos()
        {
           
            if (File.Exists("cuentas.json"))
            {
                string jsonCuentas = File.ReadAllText("cuentas.json");
                cuentas = JsonSerializer.Deserialize<List<Cuenta>>(jsonCuentas) ?? new List<Cuenta>();
            }

            
            if (File.Exists("bovedas.json"))
            {
                string jsonBovedas = File.ReadAllText("bovedas.json");
                bovedas = JsonSerializer.Deserialize<List<Boveda>>(jsonBovedas) ?? new List<Boveda>();
            }
        }

        public void CargarBovedas()
        {
            if (File.Exists("bovedas.json"))
            {
                string jsonContent = File.ReadAllText("bovedas.json");
                bovedas = JsonSerializer.Deserialize<List<Boveda>>(jsonContent) ?? new List<Boveda>();
            }
            else
            {
               
                bovedas = new List<Boveda>
        {
            new Boveda("Quetzales", 50, 100), 
            new Boveda("Quetzales", 10, 200), 
            new Boveda("Quetzales", 1, 500),  
            new Boveda("Dólares", 1, 100)     
        };
            }
        }

        public void GuardarBovedas()
        {
            string jsonContent = JsonSerializer.Serialize(bovedas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("bovedas.json", jsonContent);
        }
    }
}
