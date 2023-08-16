using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MusicUtility : MonoBehaviour
    {
        [SerializeField] TextAsset textAsset;
        [SerializeField] private Music music;

        public void AddMusic()
        {

            string[] musicNoteText = (textAsset.text).Split(",");
            List<MusicFrame> musicSheet = new();
            
        

            for (int i = 0; i < musicNoteText.Length; i += 2)
            {
                try{
                    Debug.Log(Convert.ToInt32(musicNoteText[i]));
                    int duration = Convert.ToInt32(musicNoteText[i]);
                    Notes thisFrame = (Notes)Enum.Parse(typeof(Notes), musicNoteText[i + 1], true);
                    musicSheet.Add(new MusicFrame(thisFrame, duration));
                }
                catch(Exception e){
                    Debug.Log($"Error in line {i} : {musicNoteText[i]},{musicNoteText[i + 1]}");
                    break;
                }

            }

            music.UpdateMusicSheet(musicSheet);
        }
    }
}