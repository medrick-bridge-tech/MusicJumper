using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NoteStorage
{
    public Notes noteName;
    
    public AudioClip noteSound;
}

public enum Notes
{
    A=0,Bb=1,B=2,C1=3,D1=4,E1=5,F1=6,G1=7,A1=8,B1=9,C2=10,D2=11,E2=12,F2=13,G2=14,A2=15,B2=16,Silence=17
}

[CreateAssetMenu(menuName ="Note Storage")]
public class NotesStorage : ScriptableObject
{
    public NoteStorage[] notes;
}
