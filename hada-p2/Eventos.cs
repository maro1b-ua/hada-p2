using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Eventos
    {
        public class TocadoArgs : EventArgs
        {
            public string nombre
            {
                get; set;
            }

            public string etiqueta
            {
                get; set;
            }
            public Coordenada c
            {
                get; set;
            }

            public TocadoArgs(string nombre, Coordenada c, string etiqueta)
            {
                this.nombre=nombre;
                this.c=c;
                this.etiqueta=etiqueta;
            }
        }

        public class HundidoArgs : EventArgs
        {
            public string nombre
            {
                get; set;
            }
            public HundidoArgs(string nombre)
            {
                this.nombre=nombre;
            }

        }
    }
}
