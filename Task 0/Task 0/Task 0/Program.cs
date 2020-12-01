using System;

namespace Task_0
{
    class Program
    {
        static void Main(string[] args)
        {
            IMultimedia multimedia = new Multimedia(); //IMultimedia
            Photo photo = new Photo("gdfg",123);
            M.Add(P);
            Console.WriteLine(M);
            PlayList playList = new PlayList();
            playList.Name = "Best musik";
            M.Play();
            for (int i = 0; i < M.Count(); i++)
            {
                playList.Add(M[i]);
            }
            multimedia.Add(playList);
            playList.Play();
        }
    }
}