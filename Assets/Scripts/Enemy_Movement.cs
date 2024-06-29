using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the enemy
    public float changeDirectionTime = 2f; // Time interval to change direction

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float timer;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ChangeDirection();
    }

    void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;

        // If timer reaches zero, change direction
        if (timer <= 0)
        {
            ChangeDirection();
            timer = changeDirectionTime;
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        // Choose a random direction
        float moveX = Random.Range(-1f, 1f);
        float moveY = Random.Range(-1f, 1f);

        // Create a movement vector and normalize it
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy both the enemy and the player
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
