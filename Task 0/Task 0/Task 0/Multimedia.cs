using System.Collections.Generic;
using System.Text;

namespace Task_0
{
    public class Multimedia : ICollection<MediaFile>
    {
        public List<MediaFile> MediaFiles; //IList<...>

        public Multimedia()
        {
            MediaFiles=new List<MediaFile>();
        }
        public Multimedia(List<MediaFile> mediaFiles)
        {
            MediaFiles = new List<MediaFile>();
        }
        public MediaFile this[int index]
        {
            get { return MediaFiles[index]; }
            set { MediaFiles[index] = value; }
        }
        
        public void Add(MediaFile mediaFile)
        {
            MediaFiles.Add(mediaFile);
        }
        
        public  void Remove(MediaFile mediaFile)
        {
            MediaFiles.Remove(mediaFile);
        }
        public void Remove(int index)
        {
            MediaFiles.RemoveAt(index);
        }
        public int Count()
        {
            return MediaFiles.Count;
        }
        public override string ToString()
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Multimedia\nComponents:\n");
            for (int i = 0; i < MediaFiles.Count; i++)
            {
                stringBuilder.Append($"{i + 1}:\n{MediaFiles[i]}\n");
            }
            return stringBuilder.ToString();
        }
    }
}