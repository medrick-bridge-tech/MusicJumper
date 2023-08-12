using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors{

    Blue = 1 , Purple = 2 , Red = 3 , Ora = 4 , Yellow = 5 , Green = 6 , DarkGreen = 7
}

public class Note
{
    string noteName { get; set; }
    int noteIndex { get; set; }

    public Color noteColor { get; set; }
    

    public void setNote(string Name , int Index , Color color)
    {
        noteName = Name;
        noteIndex = Index;
        noteColor = color;
    }
}

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRender;
    public Note note = new Note();
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void SetNote(string Name , int Index , Color color)
    {
        note.setNote(Name,Index,color);
        spriteRender.color = note.noteColor;
    }

}
