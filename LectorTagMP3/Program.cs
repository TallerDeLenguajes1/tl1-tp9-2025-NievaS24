string path;
bool exist;

do
{
    Console.WriteLine("Ingrese la ruta de un archivo MP3");
    path = Console.ReadLine();
    exist = File.Exists(path);
} while (!exist);

Id3v1Tag tag = Id3v1Tag.GetTag(path);

if (tag != null)
{
    Console.WriteLine("=== ID3v1 Tag ===");
    Console.WriteLine($"Título    : {tag.Title}");
    Console.WriteLine($"Artista   : {tag.Artist}");
    Console.WriteLine($"Álbum     : {tag.Album}");
    Console.WriteLine($"Año       : {tag.Year}");
    Console.WriteLine($"Comentario: {tag.Comment}");
    Console.WriteLine($"Genero    : {tag.Genre}");
}
else
{
    Console.WriteLine("No se encontró un ID3v1 tag al final del archivo.");
}

