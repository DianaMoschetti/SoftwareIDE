using System.Security.Principal;

namespace Geometria
{
    public class Circulo
    {
        private const float PI = 3.14f;
        public float Radio { get; set; }

        private float m_radio;
        
        public Circulo(float radio)
        {
            m_radio = radio;
        }
        public float CalcularPerimetro(float diametro)
        {
            return 2 * PI * m_radio;
        }

        public float CalcularSuperfie()
        {
            return PI * m_radio * m_radio;
        }
    }
}
