using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Barco
    {
        private readonly Dictionary<Coordenada, String> _CoordenadasBarco ;

        public Dictionary<Coordenada, String> CoordenadasBarco => _CoordenadasBarco;

        private string _Nombre;

        public string Nombre => _Nombre;

        private int _NumDanyos;

        public int NumDanyos => _NumDanyos;



    }
}
