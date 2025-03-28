using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_progra
{
    class Transaccion
    {
        public DateTime Fecha { get; set; } 
        public string Tipo { get; set; } 
        public int Valor { get; set; } 
        public string Detalle { get; set; } 

        public Transaccion(DateTime fecha, string tipo, int valor, string detalle)
        {
            Fecha = fecha;
            Tipo = tipo;
            Valor = valor;
            Detalle = detalle;
        }

    }
}
