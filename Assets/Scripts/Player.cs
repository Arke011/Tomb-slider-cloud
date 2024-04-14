using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    public AudioClip CollectSound;
    public AudioClip StarSound;
    public AudioClip CoinSound;
    public AudioClip Landing;
    public GameObject hitVFX;
    bool vfxInstantiated = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
        if (rb.velocity.magnitude < 0.1f)
        {
            Vector2 movement = Vector2.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                movement.y = 0;
            }
            else
            {
                movement.x = 0;
            }

            if (movement != Vector2.zero)
            {
                input = movement.normalized;
                transform.up = -input;
            }
        }
        else
        {
            input = rb.velocity.normalized; 
        }

        rb.velocity = input * 30f;
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            Destroy(other.gameObject);
            AudioSystem.Play(CollectSound);
        }
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            AudioSystem.Play(StarSound);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AudioSystem.Play(CoinSound);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(hitVFX, transform.position, Quaternion.identity);
            AudioSystem.Play(Landing);
        }
    }







}
