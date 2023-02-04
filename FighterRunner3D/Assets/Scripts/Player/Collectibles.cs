using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FR.Player
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] StatsSO stats;
        [SerializeField] int regularGloveLvl = 22;
        PlayerLevelManager playerLevelManager;

        private void Awake()
        {
            playerLevelManager = GetComponent<PlayerLevelManager>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Glove"))
            {
                playerLevelManager.GainRegularGloveLevel(regularGloveLvl);
            }

        }

        //if(other.CompareTag("collectible diamond or whatever")
        //{ diamond++ } we may trace the diamond numbers in the Stats SO script.
        //with collected diamonds player can buy extra level in the beginning of the game. 

    }
}