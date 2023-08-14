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
    A,Bb,B,C1,D1,E1,F1,G1,A1,B1,C2,D2,E2,F2,G2,A2,B2,Silence
}

[CreateAssetMenu(menuName ="Note Storage")]
public class NotesStorage : ScriptableObject
{
    public NoteStorage[] notes;
}
