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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
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
}
