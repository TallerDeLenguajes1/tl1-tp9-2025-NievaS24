using System.Text;

string path;
bool exist;
const int TAG = 128;
Encoding Latin1 = Encoding.GetEncoding("latin1");
do
{
    Console.WriteLine("Ingrese la ruta de un archivo MP3");
    path = Console.ReadLine();
    exist = File.Exists(path);
} while (!exist);
using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
{
    if (fs.Length >= TAG)
    {
        fs.Seek(-TAG, SeekOrigin.End);
        byte[] buffer = new byte[TAG];
        fs.Read(buffer, 0, TAG);
        string header = Latin1.GetString(buffer, 0, 3);
        if (header == "TAG")
        {
            string title = Latin1.GetString(buffer, 3, 30);
            string artist = Latin1.GetString(buffer, 33, 30);
            string album = Latin1.GetString(buffer, 63, 30);
            string year = Latin1.GetString(buffer, 93, 4);
            string comment = Latin1.GetString(buffer, 97, 30);
            string genre = Latin1.GetString(buffer, 127, 1);
            Console.WriteLine("=== ID3v1 Tag ===");
            Console.WriteLine($"Título    : {title}");
            Console.WriteLine($"Artista   : {artist}");
            Console.WriteLine($"Álbum     : {album}");
            Console.WriteLine($"Año       : {year}");
            Console.WriteLine($"Comentario: {comment}");
            Console.WriteLine($"Genero    : {genre}");
        }
        else
        {
            Console.WriteLine("No se encontró un ID3v1 tag al final del archivo.");
        }
    }

}
