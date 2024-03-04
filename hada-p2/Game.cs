using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Game
    {

        private bool finPartida;
        private Tablero tablero;

        private void GameLoop()
        {
            finPartida = false;
            tablero = new Tablero;

            InicializaBarcos();
            InicializaTablero();

            GameLoop();
        }

        private void InicializaBarcos()
        {

        }

        private void InicializaTablero()
        {

        }
    }
}
