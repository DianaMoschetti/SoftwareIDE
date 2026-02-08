
using AdivineElNro;

internal class Program
{
    private static void Main(string[] args)
    {
        Juego juego = new Juego();
        juego.Inicio();
    }
}

/*
 * Jugada: Esta clase genera un número aleatorio en su constructor y tiene métodos para manejar los intentos de adivinar 
 * el número. Se utiliza una propiedad para acceder a la cantidad de intentos y otra para saber si el número ha sido acertado.
Juego: La clase principal que gestiona el flujo del juego. Permite la entrada del usuario, controla los intentos y
muestra mensajes. También gestiona un récord de la menor cantidad de intentos.
Manejo de Errores: Se controla la entrada de los usuarios, asegurando que ingresen números válidos y positivos.*/