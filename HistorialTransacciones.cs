using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace practica_progra
{
    class HistorialTransacciones

    {
        private static string filePath = "historial.csv";

        public static void Registrar(string fechaHora, string boveda, string tipo, int monto)
        {
            
            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, "Fecha,Bóveda,Tipo de Transacción,Valor\n");
            }

            
            string linea = $"{fechaHora},{boveda},{tipo},{monto}";
            File.AppendAllText(filePath, linea + "\n");
        }


    }
}
