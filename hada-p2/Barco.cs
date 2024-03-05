using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hada.Eventos;

namespace Hada
{
    class Barco
    {

        //Diccionario donde se guardan las coordenadas que ocupa el barco siendo la clave la coordenada y el valor el nombre del barco

        private readonly Dictionary<Coordenada, string> _CoordenadasBarco = new Dictionary<Coordenada, string>();

        public Dictionary<Coordenada, string> CoordenadasBarco => _CoordenadasBarco;

        //Nombre del barco

        private string _Nombre;

        public string Nombre => _Nombre;

        //Daño recibido por el barco

        private int _NumDanyos;

        public int NumDanyos => _NumDanyos;

        //constructor de la clase
        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
        {
            int fila =coordenadaInicio.Fila;
            int columna = coordenadaInicio.Columna;

            this._Nombre = nombre;
            this._CoordenadasBarco.Add(coordenadaInicio, nombre);
            this._NumDanyos = 0;

            if(orientacion=='v')
            {
                for(int i=0; i<longitud; i++)
                {
                    fila++;
                    Coordenada coordenadaSiguiente = new Coordenada(fila, columna);
                    this.CoordenadasBarco.Add(coordenadaSiguiente, nombre);
                }
            }
            else if (orientacion == 'h')
            {
                for (int i = 0; i < longitud; i++)
                {
                    columna++;
                    Coordenada coordenadaSiguiente = new Coordenada(fila, columna);
                    this.CoordenadasBarco.Add(coordenadaSiguiente, nombre);
                }
            }
        }
        //Metodo de la clase en el que el barco realiza un disparo en una coordenada
        public void Disparo(Coordenada c)
        {
            Dictionary<Coordenada, string>.KeyCollection coordenadaDisparo = this.CoordenadasBarco.Keys;
            foreach (Coordenada coord in coordenadaDisparo)
            {
                if (c == coord && _CoordenadasBarco[coord]==this._Nombre)
                {
                    string situacion = _CoordenadasBarco[coord];
                    this._CoordenadasBarco[coord] = situacion + "_T";
                    int danyos = NumDanyos;
                    danyos++;
                    eventoTocado(this, new TocadoArgs(_Nombre, c, _CoordenadasBarco[coord]));
                    if (hundido() == true)
                    {
                        eventoHundido(this, new HundidoArgs(_Nombre));
                    }
                }
            }
        }

        public bool hundido()
        {
            Dictionary<Coordenada, string>.KeyCollection coordenadaHundido = this.CoordenadasBarco.Keys;
            foreach(Coordenada coord in coordenadaHundido)
            {
                string situacion = _CoordenadasBarco[coord];
                if(situacion == _Nombre)
                {
                    return false;
                }
            }
            return true;
        }

        public event EventHandler<TocadoArgs> eventoTocado;
        public event EventHandler<HundidoArgs> eventoHundido;

        public override string ToString()
        {
            string s= "";
            s= $"[{_Nombre}] - DAÑOS: [{_NumDanyos}] - HUNDIDO: [";
            if (this.hundido())
            {
                s += "True]";
            }
            else
            {
                s+="False]";
            }
            s+= " - COORDENADAS: ";

            foreach(KeyValuePair<Coordenada, string> k in _CoordenadasBarco)
            {
                s+=$"[{k.Key} :{k.Value}] ";
            }

            return s.ToString();
        }

    }
}
