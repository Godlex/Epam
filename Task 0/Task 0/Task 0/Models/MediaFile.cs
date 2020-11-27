using System.Net.Sockets;
using System.Text;

namespace Task_0
{
    public abstract class MediaFile
    {
        public string Name { get; set; }

        public MediaFile(string name)
        {
            Name = name;
        }
        
        public MediaFile()
        {
            
        }

        public abstract void Play();
      
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Item\n");
            stringBuilder.Append($"Name: {Name}\n");
            return stringBuilder.ToString();
        }
    }
}