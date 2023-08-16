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
public class Music : ScriptableObject
{
    [SerializeField][Range(20f, 180f)] float bpm;
    [SerializeField] public List<MusicFrame> musicSheet;

    

    public float GetBpm()
    {
        return bpm;
    }

    public string GetNoteName(Notes note)
    {
        return note.ToString();
    }


}
