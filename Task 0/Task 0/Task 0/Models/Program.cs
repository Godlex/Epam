using System;

namespace Task_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Multimedia M = new Multimedia(); //IMultimedia
            Photo P = new Photo("gdfg",123);
            M.Add(P);
            Console.WriteLine(M);
            PlayList playList = new PlayList();
            playList.Name = "Best musik";
            M.Play();
            for (int i = 0; i < M.Count(); i++)
            {
                playList.Add(M[i]);
            }
            playList.Play();
        }
    }
}