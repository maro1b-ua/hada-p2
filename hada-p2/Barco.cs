using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Barco
    {
        private readonly Dictionary<Coordenada, String> _CoordenadasBarco = new Dictionary<Coordenada, string>();

        public Dictionary<Coordenada, String> CoordenadasBarco => _CoordenadasBarco;

        private string _Nombre;

        public string Nombre => _Nombre;

        private int _NumDanyos;

        public int NumDanyos => _NumDanyos;

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

       

    }
}
