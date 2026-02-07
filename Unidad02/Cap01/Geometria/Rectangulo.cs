using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Rectangulo : Poligono
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        private double _base;
        private double _altura;

        public Rectangulo(double anchoBase, double altura)
        {
            _base = anchoBase;
            _altura = altura;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }

        public override double CalcularSuperficie()
        {
            return _base * _altura;
        }
    }
}