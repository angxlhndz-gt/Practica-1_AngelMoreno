using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace practica_progra
{
    class Program
    {
        static void Main(string[] args)
        {
            Autobanco autobanco = new Autobanco();
            autobanco.CargarCuentas();
            autobanco.CargarBovedas();
            autobanco.Iniciar();
            autobanco.GuardarCuentas();
            autobanco.GuardarBovedas();


        }
    }
}
