using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRender;
    public Notes NoteName;
    void OnAwake()
    {
        
    }

    public void SetNote(Notes noteName)
    {

        NoteName = noteName;
    }

}
