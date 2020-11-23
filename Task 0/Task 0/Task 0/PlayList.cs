using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Task_0
{
    public class PlayList : MediaFile  //дублировать Multimedia
    {
        public PlayList(List<MediaFile> mediaFiles) : base(mediaFiles)
        {
            MediaFiles = mediaFiles;
        }

        public PlayList():base()
        {
            
        }
        public void Play()
        {
            Console.WriteLine("Play list:");
            foreach (var m in MediaFiles)
            {
                m.Play();
            }
        }
        
    }
}