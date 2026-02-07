namespace Clases
{
    public class B : A
    {
        // internal -> no se ve fuera del proyecto (no puedo instanciarla en Program.cs)

        public B() : base("Instancia de B") //invoco a la clase clase padre A 
        {
        }
        
    }
}