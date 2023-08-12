using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    
    int noteIndex { get; set; }

    public Color noteColor { get; set; }
    

    public void setNote(int Index , Color color)
    {
        
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

    public void SetNote(int Index,Color color)
    {
        
        note.setNote(Index,color);
        spriteRender.color = note.noteColor;
    }

}
