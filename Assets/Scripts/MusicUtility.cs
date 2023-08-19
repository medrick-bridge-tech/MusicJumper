using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MusicUtility : MonoBehaviour
    {
        [SerializeField] TextAsset textAsset;
        //[SerializeField] private Music music;
        [SerializeField] private string name;
        public void AddMusic()
        {

            string[] musicNoteText = (textAsset.text).Split(",");
            List<MusicFrame> musicSheet = new();
            
        

            for (int i = 0; i < musicNoteText.Length; i += 2)
            {
                try{
                    int duration = Convert.ToInt32(musicNoteText[i]);
                    Notes thisFrameNote = (Notes)Enum.Parse(typeof(Notes), musicNoteText[i + 1], true);
                    musicSheet.Add(new MusicFrame(thisFrameNote, duration));
                }
                catch(Exception e){
                    Debug.Log($"Error in line {i} : {musicNoteText[i]},{musicNoteText[i + 1]}");
                    break;
                }

            }

            Music music = new Music();
            music.musicSheet = musicSheet;
            UnityEditor.AssetDatabase.CreateAsset(music,$"Assets/{name}.asset");
            
        }
    }
}