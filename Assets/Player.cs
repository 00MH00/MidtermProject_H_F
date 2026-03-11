using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10f;

    Rigidbody2D rb;

    public event Action PlayerDied;

    public int coinsCollected = 0;
    public int CoinsCollected => coinsCollected;

    public GameObject HeartIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        HeartIcon = GameObject.FindGameObjectWithTag("Heart");
        {
            Debug.LogWarning("No Heart object with tag 'Heart' found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            if (HeartIcon!= null)
            {
                HeartIcon.SetActive(false);
            }
            PlayerDied.Invoke();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {

            coinsCollected++;
            Destroy(collision.gameObject);
            Debug.Log("Coins Collected: " + coinsCollected);
        }
    }
}
