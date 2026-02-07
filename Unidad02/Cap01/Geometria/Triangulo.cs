using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Triangulo // Equilatero
    {
        public float Base { get; set; }
        public float Altura { get; set; }
        public float Lado3 { get; set; }

        private float _base, _altura;

        public Triangulo(float lado1, float lado2)
        {
            _base = lado1;
            _altura = lado2;
        }
        public float CalcularPerimetro()
        {
            return _base + _altura * 2;
        }

        public float CalcularSuperficie()
        {
            return (_base * _altura) / 2;
        }
    }
}