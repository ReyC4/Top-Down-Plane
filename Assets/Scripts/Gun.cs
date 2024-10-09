using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed = 20f;  // Kecepatan peluru
    public Rigidbody2D rb;           // Komponen Rigidbody2D untuk peluru

    void Start()
    {
        // Menggerakkan peluru ke depan dengan kecepatan tertentu
        rb.velocity = transform.right * bulletSpeed; // Jika peluru bergerak ke kanan, gunakan transform.right
    }

    // Fungsi ini dipanggil saat peluru bertabrakan dengan objek lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengecek apakah objek yang ditabrak memiliki tag "Enemy"
        if (collision.gameObject.tag == "Enemy")
        {
            // Menghancurkan objek musuh
            Destroy(collision.gameObject);

            // Menghancurkan peluru
            Destroy(gameObject);
        }
        else
        {
            // Jika peluru bertabrakan dengan sesuatu yang lain, tetap menghancurkan peluru
            Destroy(gameObject);
        }
    }
}
