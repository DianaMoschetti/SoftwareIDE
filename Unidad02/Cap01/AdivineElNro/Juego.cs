using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivineElNro
{
    internal class Juego
    {
        private int _intentos;
        private int _recordIntentos;
        private int _maxNumero;
        private int _intentoAdivinar = 0;
        private bool _adivinado;

        
        private bool _jugarDeNuevo = true;
        public void Inicio()
        {
            Jugada jugada = ComenzarJuego();
            while(_jugarDeNuevo)
            {
                while (!jugada.Adivino) 
                {
                    Console.WriteLine("Intente adivinar el número: ");
                   
                    while (!int.TryParse(Console.ReadLine(), out _intentoAdivinar))
                    {
                        Console.WriteLine($"Por favor, ingrese un número entero válido ingrese un número entero válido (menor a {_maxNumero}).");
                    }

                    jugada.Comparar(_intentoAdivinar, jugada);

                    if (jugada.Adivino)
                    {
                        Console.WriteLine($"¡Correcto! Adivinaste el número en {jugada.Intentos} intentos.");

                        ComparaRecord(jugada.Intentos);                       
                    }
                    else
                    {
                        Console.WriteLine("Intenta de nuevo.");
                    }
                }

            }

            Continuar();
            //invertir el do while o cambiarlo a otra cosa, pq ahora le contestes si o no sale igual
        }

        public Jugada ComenzarJuego()
        {            
            _adivinado = false;            
            _recordIntentos = 0;
            _adivinado = false;
            Console.WriteLine("Bienvenido al juego 'Adivina el Número'!");
            Console.WriteLine("El nro a adivinar estara entre el 0 y el nro máximo");
            PreguntarMaximo();          
            Jugada jugada = new Jugada(_maxNumero);
            return jugada;

        }
        public void PreguntarMaximo()
        {
            Console.Write("Ingrese el número máximo: ");

            /* mientras el usuario no ingrese un nro valido
            // con out hago que la variable se asigne adentro del tryparse,
            sin tener q inicializarla antes.
            */
            while (!int.TryParse(Console.ReadLine(), out _maxNumero) || _maxNumero <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero mayor que 0.");
            }
        }

        public void ComparaRecord(int intentos)
        {
            if (intentos < _recordIntentos)
            {
                _recordIntentos = intentos;
                Console.WriteLine($"¡Nuevo récord de intentos! ({_recordIntentos})");
            }
        }

        public void Continuar()
        {
            Console.WriteLine("Queres volver a jugar? (s/n)");
            char respuesta = Console.ReadKey(true).KeyChar;
            _jugarDeNuevo = (respuesta == 's' || respuesta == 'S') ? true : false;

            //readkey no precisa enter, ideal para menu s/n
        }


    }
}
