Console.WriteLine("Ingrese un path de un directorio:");
string direccion = Console.ReadLine();
bool existe = Directory.Exists(direccion);
while (!existe)
{
    Console.WriteLine("El directorio ingresado no existe. Ingrese uno valido por favor:");
    direccion = Console.ReadLine();
    existe = Directory.Exists(direccion);
}
string [] directorios = Directory.GetDirectories(direccion);
Console.WriteLine($"Los directorios dentro de {direccion} son:");
foreach (string directorio in directorios)
{
    string [] directorioNombre = directorio.Split("\\");
    int longitud = directorioNombre.Length;
    Console.WriteLine($"\t {directorioNombre[longitud - 1]}"); //Lista el ultimo elemento del arreglo, en este caso es el nombre del directorio
}
string [] archivos = Directory.GetFiles(direccion);
Console.WriteLine($"Los archivos dentro de {direccion} son:");
foreach (string archivo in archivos)
{
    FileInfo miArchivo = new FileInfo(archivo);
    string [] archivoNombre = archivo.Split("\\");
    int longitud = archivoNombre.Length;
    double tamaño = miArchivo.Length / 1024.00; //.Length da el tamaño en bytes
    Console.WriteLine($"\t {archivoNombre[longitud - 1]} - Tamaño: {tamaño:0.00} KB");
}