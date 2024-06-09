using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator animator;
    private float lastMoveX;

    public Transform firePoint; // Point where the bullet is shot from
    public GameObject bulletPrefab; // Prefab of the bullet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Set interpolation to smooth out movement
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Create movement vector
        Vector2 moveInput = new Vector2(moveX, moveY);
        moveVelocity = moveInput.normalized * moveSpeed;

        // Determine if the character is moving
        bool isMoving = moveInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            // Update the animator with the movement direction
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);

            // Update lastMoveX only if there's horizontal movement
            if (moveX != 0)
            {
                lastMoveX = moveX;
            }
        }
        else
        {
            // Reset the animation parameters when no input is detected
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);

            // Set to initial animation if the character stops moving horizontally
            if (lastMoveX > 0)
            {
                // Set animation for stopping after moving right
                animator.SetTrigger("StopRight");
            }
            else if (lastMoveX < 0)
            {
                // Set animation for stopping after moving left
                animator.SetTrigger("StopLeft");
            }
        }

        // Shooting logic
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
