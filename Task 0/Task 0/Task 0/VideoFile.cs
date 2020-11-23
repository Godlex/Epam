using System;
using System.Text;

namespace Task_0
{
    public class VideoFile: MediaFile

    {
        public int Lenght { get; set; }
        public VideoFile(string name,int lenght) : base(name)
        {
            Name = name;
            Lenght = lenght;
        }

        public override void Play()
        {
            Console.WriteLine($"Video Play: {Lenght}");

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Lenght: {Lenght}\n");
            return stringBuilder.ToString();
        }
    }
}