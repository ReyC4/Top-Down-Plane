using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Kecepatan peluru
    public Rigidbody2D rb;    // Rigidbody peluru
    private float incre;
    private Vector2 startPosition;

    void Start()
    {
        // Simpan posisi awal peluru
        startPosition = transform.position;
    }

    void Update()
    {
        // Tambahkan nilai pada posisi Y berdasarkan kecepatan
        //rb.velocity = transform.right * speed; // Atur kecepatan awal peluru
        incre += speed * Time.deltaTime;
        transform.position = new Vector2(startPosition.x, startPosition.y + incre);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Periksa apakah peluru mengenai objek dengan tag "Enemy"
        if (hitInfo.CompareTag("Enemy"))
        {
            // Hancurkan objek musuh
            Destroy(hitInfo.gameObject);
            // Hancurkan peluru
            Destroy(gameObject);
        }
        else
        {
            // Hancurkan peluru jika menyentuh objek lain
            Destroy(gameObject);
        }
    }
}

