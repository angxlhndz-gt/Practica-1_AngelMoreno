using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_progra
{
    class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public string Pin { get; set; }
        public int Saldo { get; set; }

        public Cuenta(string numeroCuenta, string pin, int saldo)
        {
            NumeroCuenta = numeroCuenta;
            Pin = pin;
            Saldo = saldo;
        }

        public bool ValidarPin(string pin)
        {
            return Pin == pin;
        }

        public bool Retirar(int monto)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                return true;
            }
            return false;
        }

        public void Depositar(int monto)
        {
            Saldo += monto;
        }
    }
}
