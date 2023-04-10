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
        Dictionary<int, List<string>> DicPersona = new Dictionary<int, List<string>>();
        Persona p1 = new Persona();
        List<string> listaPersona = new List<string>();
        DateTime fechaNacimiento = new DateTime(año, mes, dia);
        int menu = IngresarInt("Ingrese un numero entre el 1 y el 5");
        switch (menu)
        {
            case 1:
            Opcion1(ref dni, ref nombre, ref apellido, ref email, ref año, ref mes, ref dia);
            ArmarDic(DicPersona, listaPersona, dni, nombre, apellido, email);
            Console.WriteLine("Se ha agregado a " + nombre + " " + apellido + " a la lista");
            cantPersonas++;
            break;
            case 2:
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
    static void Opcion1(ref int dni, ref string nombre, ref string apellido, ref string email, ref int año, ref int mes, ref int dia)
    {
        dni = IngresarInt("Ingrese su dni");
        nombre = IngresarString("Ingrese su nombre");
        apellido = IngresarString("Ingrese su apellido");
        email = IngresarString("Ingrese su mail");
        año = IngresarInt("Ingrese el año de nacimiento");
        mes = IngresarInt("Ingrese su mes de nacimiento");
        dia = IngresarInt("Ingrese su dia de nacimiento");
        while(año <= 0 || mes <= 0|| dia <= 0)
        {
            Console.WriteLine("Error, datos mal ingresados");
            año = IngresarInt("Ingrese el año de nacimiento");
            mes = IngresarInt("Ingrese su mes de nacimiento");
            dia = IngresarInt("Ingrese su dia de nacimiento");
        }
    }
    static void ArmarDic(Dictionary<int, List<string>> dicPersona, List<string> listaPersona, int dni, string nombre, string apellido, string email)
    {
        listaPersona.Add(nombre + " " + apellido);
        listaPersona.Add(email);
        dicPersona.Add(dni, listaPersona);
    }

}
