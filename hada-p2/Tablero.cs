using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Tablero
    {
        private int _Tablero;

        public int Tablero
        {
            get { return _Tablero;}
            set
            {
                if(value < 4 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El rango valido esta entre 4 y 10");

                }
                _Tablero=value;
            }
        }

        private List<Coordenada> coordenadasDisparadas;

        private List<Coordenada> coordenadasTocadas;

    }
}
