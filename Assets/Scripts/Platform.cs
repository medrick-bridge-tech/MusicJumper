using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    SpriteRenderer _spriteRender;
    public Notes noteName;
    
    public void SetNote(Notes _noteName)
    {
        this.noteName = _noteName;
    }

}
