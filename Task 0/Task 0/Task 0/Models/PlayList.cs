using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Task_0
{
    public class PlayList : IPlayList //дублировать Multimedia 
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

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(MediaFile item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(MediaFile[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<MediaFile>.Remove(MediaFile item)
        {
            throw new NotImplementedException();
        }

        int ICollection<MediaFile>.Count => _count;

        public bool IsReadOnly { get; }

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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}