using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdivineElNro
{
    internal class Jugada
    {
        public int Intentos { get; set; }
        public bool Adivino { get; set; }
        public int Numero { get; set; }

        private int _numero;

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            _numero = rnd.Next(maxNumero);
            
            Numero = _numero;
            Intentos = 0;
            Adivino = false;
        }

        public Jugada Comparar(int nroPropuesto, Jugada jugada)
        {
            jugada.Intentos++;
            if (nroPropuesto == jugada.Numero)
            {
                jugada.Adivino = true;
            }
            return jugada;
        }
    }
}