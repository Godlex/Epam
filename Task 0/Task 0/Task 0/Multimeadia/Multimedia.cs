using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_0
{
    public class Multimedia : IMultimedia , IEnumerable<MediaFile>
    {
        private IList<MediaFile> _mediaFiles; //IList<...>

        public Multimedia()
        {
            _mediaFiles=new List<MediaFile>();
        }
        public Multimedia(List<MediaFile> mediaFiles)
        {
            _mediaFiles = mediaFiles;
        } 
        
        public MediaFile this[int index]
        {
            get { return _mediaFiles[index]; }
            set { _mediaFiles[index] = value; }
        }
        
        public void Add(MediaFile mediaFile)
        {
            _mediaFiles.Add(mediaFile);
        }
        
        public  void Remove(MediaFile mediaFile)
        {
            _mediaFiles.Remove(mediaFile);
        }
        public void Remove(int index)
        {
            _mediaFiles.RemoveAt(index);
        }
        public int Count()
        {
            return _mediaFiles.Count;
        }
        public void Play()
        {
            Console.WriteLine($"Multimedia list :");
            foreach (var m in _mediaFiles)
            {
                m.Play();
            }
        }

        public IEnumerator<MediaFile> GetEnumerator()
        {
            return _mediaFiles.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Multimedia\nComponents:\n");
            for (int i = 0; i < _mediaFiles.Count; i++)
            {
                stringBuilder.Append($"{i + 1}:\n{_mediaFiles[i]}\n");
            }
            return stringBuilder.ToString();
        }

      
    }
}