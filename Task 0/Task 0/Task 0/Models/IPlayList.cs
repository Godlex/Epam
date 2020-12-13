namespace Task_0
{
    using System.Collections.Generic;

    public interface IPlayList
    {

        public MediaFile this[int index] { get; set; }

        public void Add(MediaFile mediaFile);
        
        public void Remove(MediaFile mediaFile);
        public void Remove(int index);

        public int Count();

        public void Play();

    }
}