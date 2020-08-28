using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Audio_sistem
{
    public static class AudioManager
    {
        public static Dictionary<Sounds, SoundEffectInstance> allSoundsList = new Dictionary<Sounds, SoundEffectInstance>();
        public static Dictionary<string, Song> allMusicList = new Dictionary<string, Song>();
        public static string CurrentSongName { get; private set; }
        public enum Sounds {Title, Theme, Dead};
 


        static Dictionary<Sounds, string> soundNames = new Dictionary<Sounds, string>()
        {
            {Sounds.Theme,"Sponge Monger" },
            {Sounds.Title,"ComicTag3" },
            {Sounds.Dead,"Plankton Suffers" }


        };



        public static void loadSoundEffect(Sounds soundKey)
        {
            SoundEffect newSound = null;
            try
            {
                newSound = Game1.INSTANCE.Content.Load<SoundEffect>(soundNames[soundKey]);
            }
            catch
            {
                Console.WriteLine(soundKey + " Not Found");
            }
            allSoundsList.Add(soundKey, newSound?.CreateInstance());
        }

        public static void unloadSoundEffect(Sounds soundKey)
        {
            SoundEffect newSound =null;
            try
            {
                newSound = Game1.INSTANCE.Content.Load<SoundEffect>(soundNames[soundKey]);
            }
            catch
            {
                Console.WriteLine(soundKey + " Not Found");
            }
            allSoundsList.Remove(soundKey);
        }

        public static void Play(Sounds soundKey)
        {
            if (allSoundsList.ContainsKey(soundKey))
            {
                if (allSoundsList[soundKey] != null && allSoundsList[soundKey].State != SoundState.Playing)
                {
                    allSoundsList[soundKey]?.Play();
                }
            }
            else
            {
                loadSoundEffect(soundKey);
                Play(soundKey);
            }
        }


        public static void Stop(Sounds soundKey)
        {
            if (allSoundsList.ContainsKey(soundKey))
            {
                if (allSoundsList[soundKey] != null && allSoundsList[soundKey].State != SoundState.Playing)
                {
                    allSoundsList[soundKey]?.Stop();
                }
            }
            else
            {
                unloadSoundEffect(soundKey);
                Stop(soundKey);
            }
        }


        public static void loadSong(string songName)
        {
            Song newSong = null;
            try
            {
                newSong = Game1.INSTANCE.Content.Load<Song>(songName);
            }
            catch
            {
                Console.WriteLine(songName + " Not Found");
            }
            allMusicList.Add(songName, newSong);
        }
        public static void PlaySong(string songName, bool forcePlay = false, bool loop = false)
        {
            if (allMusicList.ContainsKey(songName))
            {
                if (forcePlay || CurrentSongName != songName)
                {
                    MediaPlayer.IsRepeating = loop;
                    MediaPlayer.Play(allMusicList[songName]);
                    MediaPlayer.IsRepeating = loop;
                    CurrentSongName = songName;
                }
            }
            else
            {
                loadSong(songName);
                PlaySong(songName);
            }
        }

       
    }
}
