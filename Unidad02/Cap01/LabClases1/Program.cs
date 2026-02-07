using Clases;

Console.WriteLine("Hello, World!");


A instanciaA = new A("nueva instancia A con nombre");
A instanciaASinNombre = new A();
//B instanciaB = new("nueva instancia B con nombre");
B instanciaB = new();
B instanciaBSinNombre = new();

Console.WriteLine("Instancia de A con nombre:", instanciaA);
Console.WriteLine("Instancia de A sin nombre:", instanciaASinNombre);
//Console.WriteLine("Instancia de B con nombre:", instanciaB);
Console.WriteLine("Instancia de B sin nombre:", instanciaBSinNombre);

instanciaA.MostrarNombre();

instanciaB.MostrarNombre();

instanciaB.M1();
instanciaB.M2();
instanciaB.M3();