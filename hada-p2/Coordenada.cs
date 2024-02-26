using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Coordenada
    {

        private int _Fila;
        
        public int Fila
        {
            get { return _Fila; }

        }

        private int _Columna;

        public int Columna
        {
            get { return _Columna; }

        }

        public Coordenada()
        {

        }

        public Coordenada(int fila,int columna)
        {
            _Fila = fila;
            _Columna = columna;
        }

        public Coordenada(string fila,string columna)
        {

        }

        public Coordenada(Coordenada coord)
        {

        }
    }
}
