using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Task_0
{
    using System.Text;

    public class PlayList : MediaFile, IPlayList , IEnumerable<MediaFile> 
    {
        public IList<MediaFile> MediaFiles;

        public PlayList()
        {
            MediaFiles=new List<MediaFile>();
        }
        public PlayList(List<MediaFile> mediaFiles)
        {
            MediaFiles = mediaFiles;
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
        public override void Play()
        {
            Console.WriteLine($"Play list {Name}:");
            foreach (var m in MediaFiles)
            {
                m.Play();
            }
        }

        public IEnumerator<MediaFile> GetEnumerator()
        {
           return MediaFiles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Play List {Name}\nComponents:\n");
            for (int i = 0; i < MediaFiles.Count; i++)
            {
                stringBuilder.Append($"{i + 1})\n{MediaFiles[i]}\n");
            }
            return stringBuilder.ToString();
        }
    }
}