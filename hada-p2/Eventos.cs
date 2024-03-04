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
            public String nombre
            {
                get; set;
            }

            public String etiqueta
            {
                get; set;
            }
            public Coordenada c
            {
                get; set;
            }

            public TocadoArgs(String nombre, Coordenada c, String etiqueta)
            {
                this.nombre=nombre;
                this.c=c;
                this.etiqueta=etiqueta;
            }
        }

        public class HundidoArgs : EventArgs
        {
            public String nombre
            {
                get; set;
            }
            public HundidoArgs(String nombre)
            {
                this.nombre=nombre;
            }

        }
    }
}
