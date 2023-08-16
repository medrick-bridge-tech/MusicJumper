using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    
    public int noteIndex { get; set; }

    
    

    public void setNote(int Index)
    {
        
        noteIndex = Index;
        
    }
}

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRender;
    public Note note = new Note();
    [SerializeField] Notes NoteName;
    void OnAwake()
    {
        
    }

    public void SetNote(Notes noteName)
    {

        NoteName = noteName;
    }

}
