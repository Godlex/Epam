using System;
using System.Text;

namespace Task_0
{
    public class MusicTrack : MediaFile
    {
        public int BitRate { get; set; }
        public MusicTrack(string name,int bitRate) : base(name)
        {
            Name = name;
            BitRate =bitRate;
        }
        public override void Play()
        {
            Console.WriteLine($"Musik Play: {BitRate}");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"BitRate: {BitRate}\n");
            return stringBuilder.ToString();
        }
    }
}