using System.Text;
class Id3v1Tag
{
    private const int TAG = 128;
    private static Encoding Latin1 = Encoding.GetEncoding("latin1");
    private string title;
    private string artist;
    private string album;
    private string year;
    private string comment;
    private string genre;
    public string Title
    {
        get => title;
    }
    public string Artist
    {
        get => artist;
    }
    public string Album
    {
        get => album;
    }
    public string Year
    {
        get => year;
    }
    public string Comment
    {
        get => comment;
    }
    public string Genre
    {
        get => genre;
    }
    public static Id3v1Tag GetTag(string path)
    {
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
                    return new Id3v1Tag
                    {
                        title = Latin1.GetString(buffer, 3, 30),
                        artist = Latin1.GetString(buffer, 33, 30),
                        album = Latin1.GetString(buffer, 63, 30),
                        year = Latin1.GetString(buffer, 93, 4),
                        comment = Latin1.GetString(buffer, 97, 30),
                        genre = Latin1.GetString(buffer, 127, 1),
                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}