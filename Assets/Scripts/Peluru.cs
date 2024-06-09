using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Kecepatan peluru
    public Rigidbody2D rb;    // Rigidbody peluru

    void Start()
    {
        rb.velocity = transform.right * speed; // Atur kecepatan awal peluru
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Hancurkan peluru jika menyentuh objek lain
        Destroy(gameObject);
    }
}
