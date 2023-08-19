using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shredder : MonoBehaviour
{
    Jumper _player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag($"platform"))
        {
            _player.DestroyPlatform(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            DestroyPlayer(collision.gameObject);
        }
        
    }

    private void Start()
    {
         _player = FindObjectOfType<Jumper>();
    }

    void DestroyPlayer(GameObject player)
    {
        Destroy(player);
        SceneManager.LoadScene("GameOver");
    }

}
