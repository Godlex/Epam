using System;

namespace Task_0
{
    class Program
    {
        static void Main(string[] args)
        {
            IMultimedia multimedia = new Multimedia()
            {
                new Photo("fdafa",1),
                new MusicTrack("fdsf",14213),
                new PlayList()
                {
                    new VideoFile("dsaf",124),
                    new VideoFile("dsaf",124),
                    new VideoFile("dsaf",124),
                    new VideoFile("dsaf",124),
                    new PlayList()
                    {
                        new MusicTrack("fdsf",421),
                        new Photo("fdafa",1),
                        new MusicTrack("fdsf",14213)
                    }
                }
            };
            Console.WriteLine(multimedia);
            multimedia.Play();
        }
    }
}