using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    public float moveSpeed = 20f;
    public AudioClip CollectSound;
    public AudioClip StarSound;
    public AudioClip CoinSound;
    public AudioClip Landing;
    public GameObject landParticles;
    Vector2 lvl2;
    Vector2 lvl3;
    bool hasLanded;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lvl2 = new Vector2(10.4f, 5.5f);
        lvl3 = new Vector2(-0.49f, -0.91f);

        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<Player>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        var newInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(newInput.x) > 0 && Mathf.Abs(newInput.y) > 0)
        {
            newInput.y = 0;
        }

        if (rb.velocity.magnitude < 0.1f && !hasLanded && newInput != input && newInput != Vector2.zero)
        {
            if (landParticles != null)
            {
                GameObject particles = Instantiate(landParticles, transform.position, Quaternion.identity);
                AudioSystem.Play(Landing);
                StartCoroutine(destroyVFX(particles));
            }
            hasLanded = true;
        }

        if (newInput != Vector2.zero && rb.velocity.magnitude < 0.1f)
        {
            input = newInput;
            transform.up = -input;
            hasLanded = false;
        }
        rb.velocity = input * moveSpeed;
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
        if (other.gameObject.CompareTag("TP"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            transform.position = lvl2;
        }
        if (other.gameObject.CompareTag("TP2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            transform.position = lvl3;
        }
        if (other.gameObject.CompareTag("TP3"))
        {
            SceneManager.LoadScene("LVL1");
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    public IEnumerator destroyVFX(GameObject particle)
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(particle);
    }
}
