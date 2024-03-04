using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Tablero
    {
        // Indica el tamaño que tendra el tablero
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

        //Se guardara una lista de las coordenadas que han sido disparadas
        private List<Coordenada> coordenadasDisparadas = new List<Coordenada>();

        //Se guardaran las coordenadas de los disparos que han acertado a un barco
        private List<Coordenada> coordenadasTocadas = new List<Coordenada>();

        ////Se guarda una lista de los nombre de los barcos que hay en el tablero 
        private List<Barco> barcos = new List<Barco>();

        //Se guarda el nombre de los barcos que han sido eliminados
        private List<Barco> barcosEliminados = new List<Barco>();

        //Diccionario que guarda la coordenada y el estado de un casilla
        private Dictionary<Coordenada, string> casillasTablero = new Dictionary<Coordenada, string>();

        //Constructor
        public Tablero(int tamTablero, List<Barco> barcos)
        {
            this._Tablero=tamTablero;
            this.barcos.AddRange(barcos);

            foreach(Barco b in barcos)
            {
                b.eventoTocado += TocadoArgs;
                b.eventoHundido += HundidoArgs;
            }
            inicializaCasillasTablero();
        }

        private void inicializaCasillasTablero()
        {
            int x=0;
            int y=0;
            for(x=0; x < this._Tablero; x++)
            {
                for(y=0; y < this._Tablero; y++)
                {
                    Coordenada c = new Coordenada(x, y);
                    this.casillasTablero.Add(c, "AGUA");
                }
            }
            foreach(var barco in barcos)
            {
                foreach(var elemento in barco.CoordenadasBarco)
                {
                    casillasTablero[elemento.Key]=elemento.Value;
                }
            }
        }
    }
}
