using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini diletakkan pada gameobject kosong dgn nama Object Pooling
public class MyObjectPool : MonoBehaviour
{
    private static MyObjectPool instance;

    public int size; //seberapa banyak setiap gameobject
    public GameObject[] prefabs;

    public List<MyPoolObject> poolObjects;


    //0. membuat singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static MyObjectPool GetInstance() {
        return instance;
    }

    //0 batas singleton

    void Start()
    {
        instantiateObjects();
    }


    //1. berguna untuk membuat beberapa object dalam sebuah pool
    private void instantiateObjects()
    {
        poolObjects = new List<MyPoolObject>();
        for (int i = 0; i < size; i++)
        {
            foreach (GameObject go in prefabs)
            {
                //nambahin object ke list, dan get scriptnya MyPoolObject 
                // parameter transform pada Instatiate adalah parent.
                //parent pada kasus ini adalah gameobject Object Pool
                poolObjects.Add(Instantiate(go, transform).GetComponent<MyPoolObject>());
            }
        }
    }

    //2. request setiap gameobject pada PoolObjects
    public MyPoolObject requestObject(MyPoolObjectType type)
    {
        foreach (MyPoolObject po in poolObjects)
        {
            if (po.type == type && !po.isActive())
            {
                return po;
            }
        }
        return null;
    }


 



}