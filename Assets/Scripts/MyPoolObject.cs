using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyPoolObjectType //terdiri dari tiga type PoolObject
{
    BULLET, BOLT, EXPLOSION
}

//script ini diletakkan pada tiap prefab seperti bullet, bolt, explosion
public class MyPoolObject : MonoBehaviour
{
    public MyPoolObjectType type;
    
    void Start()
    {
        deactivate();
    }

    //mengaktivasi gameobject, dengan memberikan position
    public void activate(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);

        transform.position = position;
        transform.rotation = rotation;
    }

    //mengaktivasi dengan menonaktifkan gameobject
    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    internal bool isActive()
    {
        return gameObject.activeInHierarchy;
     
    }
}