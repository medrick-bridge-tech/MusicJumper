using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject platformDestroyVFX;
    
    public NotesStorage notesStorage;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag($"platform"))
        {
            Jump();
            
            DestroyPlatform(collision.gameObject);
        }
    }

    public void DestroyPlatform(GameObject platform)
    {
        PlaySound(platform);
        PlayVFX(platformDestroyVFX,platform);
        Destroy(platform);
    }
    
    void PlaySound(GameObject platform)
    {
        Notes noteName = platform.GetComponent<Platform>().noteName;

        int index = (int)noteName;

        audioSource.PlayOneShot(notesStorage.notes[index].noteSound);
    }

    [Obsolete("Obsolete")]
    void PlayVFX(GameObject vfx,GameObject target)
    {
        GameObject effect = Instantiate(vfx,target.transform.position,Quaternion.identity);
        effect.GetComponent<ParticleSystem>().startColor = target.GetComponent<SpriteRenderer>().color;
        Destroy(effect,1f);
    }

    
    public void SetJumpForce(float force)
    {
        jumpForce = force;
    }
    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    
    void Jump()
    {
        Vector2 playerVelocity = rigidBody.velocity;
        playerVelocity.y = jumpForce;
        rigidBody.velocity = playerVelocity;
    }

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        Vector3 direction = Vector3.zero;
        direction.x = horizontalAxis;

        Vector3 translate = direction * (moveSpeed * Time.deltaTime);
        transform.Translate(translate);
    }
}
