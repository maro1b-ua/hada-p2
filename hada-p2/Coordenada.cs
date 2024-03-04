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
            set
            {
                if (Fila < 0)
                    throw new ArgumentOutOfRangeException(nameof(Fila),
                          "El valor de la fila debe ser positivo");

                _Fila = Fila;
            }

        }

        private int _Columna;

        public int Columna
        {
            get { return _Columna; }
            set
            {
                if (Columna < 0)
                    throw new ArgumentOutOfRangeException(nameof(Columna),
                          "El valor de la columna debe ser positivo");

                _Columna = Columna;
            }

        }

        public Coordenada()
        {
            _Fila = 0;
            _Columna = 0;

        }

        public Coordenada(int fila,int columna)
        {
            _Fila = fila;
            _Columna = columna;
        }

        public Coordenada(string fila,string columna)
        {
            _Fila = int.Parse(fila);
            _Columna = int.Parse(columna);

        }

        public Coordenada(Coordenada coord)
        {
            _Fila = coord.Fila;
            _Columna = coord.Columna;
        }

        override
        public string ToString()
        {
            return $"({_Fila},{_Columna})";
        }

        override
        public int GetHashCode()
        {
            return this.Fila.GetHashCode() ^ this.Columna.GetHashCode();
        }

        override
        public bool Equals(Object o)
        {
            if(o == null )
            {
                return false;
            }

            return true;
        }

        public bool Equals(Coordenada coord)
        {
            if (_Fila == coord.Fila && _Columna == coord.Columna)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
