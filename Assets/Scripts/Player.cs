using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public GameObject lazer;

    public Transform shootingPoint;

    GameController gameController;

    SliderController hpController;

    public AudioSource aus;

    public AudioClip shootingSound;

    public AudioClip haveStar;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        hpController = FindObjectOfType<SliderController>();
    }

    public float minX = -15.17f;
    public float maxX = 3.45f;
    public float minY = -1.1f;
    public float maxY = 7.2f;

    void Update()
    {
        if (gameController.IsGameover())
        {
            return;
        }

        float xDir = Input.GetAxisRaw("Horizontal");
        float newXPosition = transform.position.x + Vector3.right.x * moveSpeed * xDir * Time.deltaTime;
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX); 

        float yDir = Input.GetAxisRaw("Vertical");
        float newYPosition = transform.position.y + Vector3.up.y * moveSpeed * yDir * Time.deltaTime;
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(lazer && shootingPoint)
        {
            if(aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(lazer, shootingPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            hpController.DecreaseHP();
            if(hpController.GetHP() == 0)
            {
                gameController.SetGameoverState(true);
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Star"))
        {

            if (aus && haveStar)
            {
                aus.PlayOneShot(haveStar);
            }
            gameController.ScoreIncrement();
            Destroy(collision.gameObject);
        }
    }
}
