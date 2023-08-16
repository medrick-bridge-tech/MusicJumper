using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

[Serializable]
public class MusicFrame
{
    public Notes noteName;
    public int duration;
    
    public MusicFrame(Notes notename, int duration)
    {
        noteName = notename;
        this.duration = duration;
    }
    
    public int GetIndex(Notes notename)
    {
        int index = (int)notename;
        return index;
    }

    public int GetDuration()
    {
        return duration;
    }
    

}

[CreateAssetMenu(fileName = "New Music", menuName = "Music")]
public class MusicNote : ScriptableObject
{
    [SerializeField] TextAsset textAsset;
    [FormerlySerializedAs("BPM")] [SerializeField][Range(20f, 180f)] float bpm;
    public List<MusicFrame> musicSheet;

    public float GetBpm()
    {
        return bpm;
    }

    public string GetNoteName(Notes note)
    {
        return note.ToString();
    }
    public void AddMusic()
    {

        string[] musicNoteText = (textAsset.text).Split(",");
        

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
        
    }

}
