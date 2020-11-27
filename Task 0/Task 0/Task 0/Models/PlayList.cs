using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Task_0
{
    public class PlayList : MediaFile  //дублировать Multimedia
    {
        public List<MediaFile> MediaFiles;
        
        public PlayList()
        {
            MediaFiles=new List<MediaFile>();
        }
        public PlayList(List<MediaFile> mediaFiles)
        {
            MediaFiles = new List<MediaFile>();
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
        
    }
}