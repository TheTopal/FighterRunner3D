using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FR.Enemy
{
    public class LevelHolder : MonoBehaviour
    {
        [SerializeField] StatsSO stats;
        [HideInInspector] public int enemyLevel;

        void Awake()
        {
            enemyLevel = stats.level;    
        }
        


    }
}