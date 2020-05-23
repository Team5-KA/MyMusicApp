using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Model
{
    public static class MusicManager
    {

        public static void GetAllMusics(ObservableCollection<Music> musics)
        {
            var allMusics = getMusics();
            musics.Clear();
            allMusics.ForEach(music => musics.Add(music)); //lambda expression
        }

        public static void GetMusicsByCategory(ObservableCollection<Music> musics, MusicCategory category)
        {
            var allMusics = getMusics();
            var filteredMusics = allMusics.Where(music => music.Category == category).ToList();
            musics.Clear();
            filteredMusics.ForEach(music => musics.Add(music)); //lambda expression
        }

        private static List<Music> getMusics()
        {
            var musics = new List<Music>();
            musics.Add(new Music("Guitar", MusicCategory.Instrumental));
            musics.Add(new Music("Harp", MusicCategory.Instrumental));
            musics.Add(new Music("Piano", MusicCategory.Instrumental));
            musics.Add(new Music("lullabygoodnight", MusicCategory.SleepMusic));
            musics.Add(new Music("rockabyebaby", MusicCategory.SleepMusic));
            musics.Add(new Music("twinkle", MusicCategory.SleepMusic));

            return musics;

        }
    }
}
