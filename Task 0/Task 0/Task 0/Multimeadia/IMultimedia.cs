using System.Collections.Generic;

namespace Task_0
{
    public interface IMultimedia // метод
    {

        void Add(MediaFile mediaFile);
        void Remove(MediaFile mediaFile);
        void Remove(int index);
        public int Count();
        public void Play();
    }
}