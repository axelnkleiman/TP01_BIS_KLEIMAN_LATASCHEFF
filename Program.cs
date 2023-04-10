 using System.Collections.Generic;
internal class Program
{
    const int NUMSALIR = 5;
    private static void Main(string[] args)
    {
        int dni = -1;
        string nombre = "";
        string apellido = "";
        string email = "";
        int cantPersonas = 0; 
        int año = 0;
        int mes = 0;
        int dia = 0; 
        int cantVotar = 0;
        Dictionary<int, List<string>> DicPersona = new Dictionary<int, List<string>>();
        Persona p1 = new Persona();
        List<string> listaPersona = new List<string>();
        List<int> listaEdades = new List<int>();
        DateTime fechaNacimiento = new DateTime();
        DateTime fechaActual = DateTime.Now;
        int añoActual = fechaActual.Year;
        int menu = IngresarInt("Ingrese un numero entre el 1 y el 5");
        switch (menu)
        {
            case 1:
            Opcion1(ref dni, ref nombre, ref apellido, ref email, ref año, ref mes, ref dia, listaEdades, añoActual);
            fechaNacimiento = new DateTime(año, mes, dia);
            if(fechaNacimiento > DateTime.Now)
            {
                Console.WriteLine("Error, fecha mal ingresada");
                año = IngresarInt("Ingrese su año de nacimiento");
                mes = IngresarInt("Ingrese su mes de nacimiento");
                dia = IngresarInt("Ingrese su dia de nacimiento");
            }
            ArmarDic(DicPersona, listaPersona, dni, nombre, apellido, email);
            Console.WriteLine("Se ha agregado a " + nombre + " " + apellido + " a la lista");
            cantPersonas++;
            break;
            case 2:
            if(cantPersonas == 0)
            {
                Console.WriteLine("No se ingreso ninguna persona");
            }else
            {
                VerEstadisticas(cantPersonas, ref cantVotar, fechaNacimiento, listaEdades);
            }
            break;
            case 3:
            break;
            case 4:
            break;
            case 5:
            break;
            default:
            break;
        }

    }
    static int IngresarInt(string mensaje)
    {  
        int num;
        Console.WriteLine(mensaje);
        num =int.Parse(Console.ReadLine());
        return num;
    }
    static string IngresarString(string mensaje)
    {
        string palabra;
        Console.WriteLine(mensaje);
        palabra = Console.ReadLine();
        return palabra;
    }
    static void Opcion1(ref int dni, ref string nombre, ref string apellido, ref string email, ref int año, ref int mes, ref int dia, List<int> listaEdades, int añoActual)
    {
        dni = IngresarInt("Ingrese su dni");
        nombre = IngresarString("Ingrese su nombre");
        apellido = IngresarString("Ingrese su apellido");
        email = IngresarString("Ingrese su mail");
        año = IngresarInt("Ingrese su año de nacimiento");
        mes = IngresarInt("Ingrese su mes de nacimiento");
        dia = IngresarInt("Ingrese su dia de nacimiento");
        listaEdades.Add(añoActual - año);
    }
    static void ArmarDic(Dictionary<int, List<string>> dicPersona, List<string> listaPersona, int dni, string nombre, string apellido, string email)
    {
        listaPersona.Add(nombre + " " + apellido);
        listaPersona.Add(email);
        dicPersona.Add(dni, listaPersona);
    }

    static void VerEstadisticas(int cantPersonas, ref int cantVotar, DateTime fechanacimiento, List<int> listaEdades)
    {
        double promedio = 0;
        int suma = 0;
        DateTime fechaHoy = DateTime.Now;
        fechaHoy.Subtract(fechanacimiento);
        if(fechaHoy.Year >= 16)
        {
            cantVotar++;
        }
        for (int i = 0; i < cantPersonas; i++)
        {
            suma = suma + listaEdades[i];
        }
        promedio = suma/cantPersonas;
        Console.WriteLine("Cantidad de personas habilitadas para votar: " + cantVotar);
        Console.WriteLine("Cantidad de personas ingresadas: " + cantPersonas);
        Console.WriteLine("Promedio de edades: " + promedio);
    }

}
