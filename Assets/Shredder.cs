using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    Jumper _player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        _player.DestroyPlatform(collision.gameObject);
    }

    private void Start()
    {
         _player = FindObjectOfType<Jumper>();
    }


}
