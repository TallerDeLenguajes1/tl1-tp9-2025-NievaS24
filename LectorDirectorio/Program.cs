string direccion;
Console.WriteLine("Ingrese un path de un directorio:");
direccion = Console.ReadLine();
bool existe = Directory.Exists(direccion);
while (!existe)
{
    Console.WriteLine("El directorio ingresado no existe. Ingrese uno valido por favor:");
    direccion = Console.ReadLine();
    existe = Directory.Exists(direccion);
}
