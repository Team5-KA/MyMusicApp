﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Model
{
    public enum MusicCategory
    {

        Instrumental,
        SleepMusic
    }

    public class Music
    {
        public string Name { get; set; }
        public MusicCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Music(string name, MusicCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"/Assets/Audio/{category}/{name}.mp3";
            ImageFile = $"/Assets/Images/{category}/{name}.png";
        }
    }
}
