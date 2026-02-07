using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Cuadrado : Rectangulo
    {
        private double _lado;
        public Cuadrado(double lado) : base(lado, lado)
        {
            _lado = lado;
        }

        public override double CalcularPerimetro()
        {
            return 4 * _lado;
        }

        public override double CalcularSuperficie()
        {
            return _lado * _lado;
        }
    }
}