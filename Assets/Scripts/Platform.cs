using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer _spriteRender;
    public Notes noteName;
    void OnAwake()
    {
        
    }

    public void SetNote(Notes _noteName)
    {

        this.noteName = _noteName;
    }

}
