using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScrollBackground : MonoBehaviour
{
		//adapun Transform terdiri 2 buah gameobject yang berfungsi sebagai background
    public Transform[] background;
    public float speed;

    [Header("Pos Y Diatas Kamera")]
    public float topPosY;

    [Header("Pos Y Dibawah Kamera")]
    public float bottomPosY;


    void Update()
    {
        positionUpdate();
        checkPosition();
    }


		//check posisi, kalau udah terlalu bawah, pindahin keatas
    private void checkPosition()
    {
        if (background[0].transform.position.y < bottomPosY)
        {
            background[0].transform.position = new Vector3 (0,topPosY,0);
        }
        if (background[1].transform.position.y < bottomPosY)
        {
            background[1].transform.position = new Vector3(0, topPosY, 0);
        }
    }


		//menggeser background kebawah
    private void positionUpdate()
    {
        var movement = Time.deltaTime * speed;
        background[0].transform.position = new Vector3(0, background[0].position.y - movement, 0);
        background[1].transform.position = new Vector3(0, background[1].position.y - movement, 0);
    }
}