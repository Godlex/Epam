using System;
using System.Text;

namespace Task_0
{
    public class Photo : MediaFile
    {
        public int Quality
        {
            get;
            // set
            // {
            //     if (value < 0) throw new AggregateException();
            // };
            private set;

        }

        public Photo(string name,int quality) : base(name)
        {
            Name = name;
            //проверка quality
            Quality = quality;
        }

        public override void Play()
        {
            Console.WriteLine($"Photo Play: {Quality}");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Quality: {Quality}\n");
            return stringBuilder.ToString();
        }
    }
}