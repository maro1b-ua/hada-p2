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
            public TocadoArgs(String nombre, Coordenada c, String etiqueta)
            {

            }
        }

        public class HundidoArgs : EventArgs
        {
            public HundidoArgs(String nombre)
            {

            }

        }
    }
}
