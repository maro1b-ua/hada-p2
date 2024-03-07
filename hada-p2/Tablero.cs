using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hada.Eventos;


namespace Hada
{
    class Tablero
    {
        // Indica el tamaño que tendra el tablero
        private int _Tablero;

        public int TamTablero
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
            this.TamTablero=tamTablero;
            this.barcos.AddRange(barcos);

            for(int i=0; i<barcos.Count(); i++)
            {
                barcos[i].eventoTocado += cuandoEventoTocado;
                barcos[i].eventoHundido += cuandoEventoHundido;
            }
            inicializaCasillasTablero();
        }

        //Metodo que iniciara el tablero 
        private void inicializaCasillasTablero()
        {
            int x=0;
            int y=0;
            for(x=0; x < this.TamTablero; x++)
            {
                for(y=0; y < this.TamTablero; y++)
                {
                    Coordenada c = new Coordenada(x, y);
                    this.casillasTablero.Add(c, "AGUA");
                }
            }
            foreach(var barco in this.barcos)
            {
                foreach(var elemento in barco.CoordenadasBarco)
                {
                    this.casillasTablero[elemento.Key]=elemento.Value;
                }
            }
        }

        //Metodo donde se da una coordenada a disparar en el tablero
        public void Disparar(Coordenada c)
        {
            if(c.Columna > TamTablero|| c.Fila > TamTablero)
            {
                throw new ArgumentOutOfRangeException($"La coordenada ({c.Fila},{c.Columna}) esta fuera de las dimensiones del tablero");
            }
            else
            {
                this.coordenadasDisparadas.Add(c);
                if (!coordenadasTocadas.Contains(c) && casillasTablero[c] != "AGUA")
                {
                    coordenadasTocadas.Add(c);
                    for(int i=0; i<barcos.Count; i++)
                    {
                        barcos[i].Disparo(c);
                    }
                }
            }
        }

        //Metodo que dibuja el tablero de juegos
        public string DibujarTablero()
        {
            string s = "";
            int contador= 0;
            foreach(var estado in this.casillasTablero)
            {
                s+= $"[{estado.Value}]";
                if(contador == TamTablero - 1)
                {
                    s+="\n";
                    contador=0;
                }
                else
                {
                    contador++;
                }
            }

            return s.ToString();
        }


        //Metodo ToString()
        public override string ToString()
        {
            string s="";

            foreach(var barco in barcos)
            {
                s+=barco.ToString() + "\n";
            }

            s+="\n";

            s+=" Coordenadas disparadas: ";
            foreach(var coordenada in coordenadasDisparadas)
            {
                s+=coordenada.ToString();
            }
            s+="\n";
            s+=" Coordenadas tocadas: ";
            foreach(var coordenada in coordenadasTocadas)
            {
                s+=coordenada.ToString();
            }

            s+="\n\n\n";
            s+="CASILLAS TABLERO\n";
            s+="------- \n";
            s+=DibujarTablero();

            return s.ToString();
        }

        //Metodo que activara tras suceder el evento de un barco disparado 
        private void cuandoEventoTocado(object sender, TocadoArgs evento)
        {
            Barco barco = (Barco)sender;
            casillasTablero[evento.c]=evento.etiqueta;
            System.Console.WriteLine($"TABLERO: Barco[{barco.Nombre}] tocado en Coordenada: [{evento.c}]");
        }

        //Metodo que se activara tras suceder el evento de un barco hundido
        private void cuandoEventoHundido(object sender, HundidoArgs evento)
        {
            Barco barco = (Barco)sender;
            barcosEliminados.Add(barco);
            System.Console.WriteLine($"TABLERO: Barco [{barco.Nombre}] hundido!!");

            if(barcos.Count == barcosEliminados.Count)
            {
                eventoFinPartida(this, new EventArgs());
            }

        }

        //Evento que finalizara la partida 
        public EventHandler<EventArgs> eventoFinPartida;
    }
}
