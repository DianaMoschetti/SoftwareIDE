using Geometria;

Console.WriteLine("Elija una figura geométrica");
Console.WriteLine("1. Triángulo");
Console.WriteLine("2. Cuadrado");
Console.WriteLine("3. Rectángulo");
Console.WriteLine("4. Círculo");

var opcion = Console.ReadLine();

switch (opcion)
{
    case "1":
        Console.WriteLine("Ingrese la base del triángulo:");
        float baseTriangulo = float.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la altura del triángulo:");
        float alturaTriangulo = float.Parse(Console.ReadLine());
        Triangulo triangulo = new Triangulo(baseTriangulo, alturaTriangulo);
        Console.WriteLine($"Perímetro del triángulo: {triangulo.CalcularPerimetro()}");
        Console.WriteLine($"Superficie del triángulo: {triangulo.CalcularSuperficie()}");
        break;
    case "2":
        Console.WriteLine("Ingrese el lado del cuadrado:");
        double ladoCuadrado = double.Parse(Console.ReadLine());
        Cuadrado cuadrado = new Cuadrado(ladoCuadrado);
        Console.WriteLine($"Perímetro del cuadrado: {cuadrado.CalcularPerimetro()}");
        Console.WriteLine($"Superficie del cuadrado: {cuadrado.CalcularSuperficie()}");
        break;
    case "3":
        Console.WriteLine("Ingrese la base del rectángulo:");
        double baseRectangulo = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la altura del rectángulo:");
        double alturaRectangulo = double.Parse(Console.ReadLine());
        Rectangulo rectangulo = new Rectangulo(baseRectangulo, alturaRectangulo);
        Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro()}");
        Console.WriteLine($"Superficie del rectángulo: {rectangulo.CalcularSuperficie()}");
        break;
    case "4":
        Console.WriteLine("Ingrese el radio del círculo:");
        float radioCirculo = float.Parse(Console.ReadLine());
        Circulo circulo = new Circulo(radioCirculo);
        Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro(2 * radioCirculo)}");
        Console.WriteLine($"Superficie del círculo: {circulo.CalcularSuperfie()}");
        break;
    default:
        Console.WriteLine("Opción no válida.");
        break;
}
