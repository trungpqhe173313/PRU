using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    Rigidbody2D m_rb;

    public float speed;

    public float timeToDestroy;

    AudioSource aus;

    public AudioClip targetSound;

    // Start is called before the first frame update
    void Start()
    {
        aus = FindObjectOfType<AudioSource>();
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Asteroid"))
        {
            if(aus && targetSound)
            {
                aus.PlayOneShot(targetSound);
            }
            Destroy(collision.gameObject); 
            Destroy(gameObject);
        } else if(collision.CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }
}
