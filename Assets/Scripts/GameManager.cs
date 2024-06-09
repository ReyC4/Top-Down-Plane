using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        [SerializeField] GameObject activePlayer;
        public GameObject playerPrefab;

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

        public static GameManager GetInstance()
        {
            return instance;
        }

        void Start()
        {
            spawnPlayer();
        }
        private void spawnPlayer()
        {
            activePlayer = Instantiate(playerPrefab);
        }

        //mendapatkan poosisi transform player
        public Vector3 getPlayerPosition()
        {
            if (activePlayer != null)
            {
                return activePlayer.transform.position;
            }
            return Vector3.zero;
        }


    }
}