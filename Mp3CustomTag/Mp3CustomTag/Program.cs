using TagLib;
using TagLib.Id3v2;

namespace Mp3CustomTag
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = TagLib.File.Create(@"I:\song.mp3");
            var t = (TagLib.Id3v2.Tag)f.GetTag(TagTypes.Id3v2);
            var p = PrivateFrame.Get(t, "AlbumType", true);
            p.PrivateData = System.Text.Encoding.Unicode.GetBytes("TAG CHANGED");
            f.Tag.Album = "test";
            f.Save();
        }
    }
}
