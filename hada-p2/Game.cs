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

        public Game() {
            finPartida = false;
            gameLoop();
        }

        private void gameLoop() {
            // Crear barcos
            Barco barco1 = new Barco("Barco1", 3, 'h', new Coordenada(1, 1));
            Barco barco2 = new Barco("Barco2", 2, 'v', new Coordenada(0, 2));
            // Agregar más barcos aquí

            // Inicializar tablero
            Tablero tablero = new Tablero(6, new List<Barco> { barco1, barco2 });

            // Evento para finalizar el juego
            tablero.eventoFinPartida += (sender, args) => {
                finPartida = true;
                Console.WriteLine("¡Todos los barcos han sido hundidos! Fin de la partida.");
            };

            while (!finPartida) {
                Console.WriteLine(tablero.ToString());

                Console.WriteLine("Introduce una coordenada (fila,columna): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "s") {
                    finPartida = true;
                    break;
                }

                string[] coordenadas = input.Split(',');

                if (coordenadas.Length == 2 && int.TryParse(coordenadas[0], out int fila) &&
                    int.TryParse(coordenadas[1], out int columna)) {
                    Coordenada disparoCoordenada = new Coordenada(fila, columna);
                    try {
                        tablero.Disparar(disparoCoordenada);
                    }
                    catch (ArgumentOutOfRangeException ex) {
                        Console.WriteLine(ex.Message);
                    }

                }
                else {
                    Console.WriteLine("Formato de coordenada incorrecto. Vuelve a intentarlo.");
                }
            }

            Console.WriteLine("Juego finalizado.");
        }
    }
}
