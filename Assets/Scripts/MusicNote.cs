using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
public class MusicFrame
{
    public Notes NoteName;
    public int duration;
    
    public MusicFrame(Notes noteName, int Duration)
    {
        NoteName = noteName;
        duration = Duration;
    }
    
    public int GetIndex(Notes NoteName)
    {
        int Index = (int)NoteName;
        return Index;
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
    [SerializeField][Range(20f, 180f)] float BPM;
    public List<MusicFrame> MusicSheet;

    public float GetBPM()
    {
        return BPM;
    }

    public string GetNoteName(Notes note)
    {
        return note.ToString();
    }
    public void AddMMusic()
    {

        string[] MusicNoteText = (textAsset.text).Split(",");
        

        for (int i = 0; i < MusicNoteText.Length; i += 2)
        {
            try{
                Debug.Log(Convert.ToInt32(MusicNoteText[i]));
                int duration = Convert.ToInt32(MusicNoteText[i]);
                Notes thisFrame = (Notes)Enum.Parse(typeof(Notes), MusicNoteText[i + 1], true);
                MusicSheet.Add(new MusicFrame(thisFrame, duration));
            }
            catch(Exception e){
                Debug.Log($"Error in line {i} : {MusicNoteText[i]},{MusicNoteText[i + 1]}");
                break;
            }
            
        }
        
    }

}
