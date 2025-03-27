using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_progra
{
    class Boveda
    {
        public string TipoMoneda { get; set; }
        public int Denominacion { get; set; }
        public int Cantidad { get; set; }

        public Boveda(string tipoMoneda, int denominacion, int cantidad)
        {
            TipoMoneda = tipoMoneda;
            Denominacion = denominacion;
            Cantidad = cantidad;
        }

        public bool Retirar(int monto)
        {
            int billetesNecesarios = monto / Denominacion;
            if (Cantidad >= billetesNecesarios)
            {
                Cantidad -= billetesNecesarios;
                return true;
            }
            return false;
        }

        public void Depositar(int monto)
        {
            Cantidad += monto / Denominacion;
        }

    }
}
