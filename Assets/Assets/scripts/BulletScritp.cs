using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScritp : MonoBehaviour
{
    public AudioClip Sound;
    public float speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
    }

    public void Setdirection(Vector2 direction) 
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        meatmovimiento Meat = collision.GetComponent<meatmovimiento>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        if (Meat != null)
        {
            Meat.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }

    
    }
