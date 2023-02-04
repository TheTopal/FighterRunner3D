using FR.Enemy;
using UnityEngine;

namespace FR.Player
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] StatsSO stats;
        PlayerLevelManager playerLevelManager;
        PlayerAnimationChanger playerAnimationChanger;
        PlayerMovement playerMovement;
        public int currentEnemyLevel;
        public bool playerCanBeat;
        public bool enemyCanBeat;

        void Awake()
        {
            playerLevelManager = GetComponent<PlayerLevelManager>();
            playerAnimationChanger= GetComponent<PlayerAnimationChanger>();
            playerMovement= GetComponent<PlayerMovement>();
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy"))
            {
                LevelHolder enemyLevelHolder = other.GetComponent<LevelHolder>(); 
                if(enemyLevelHolder != null) 
                {
                    currentEnemyLevel = enemyLevelHolder.enemyLevel;
                    if (stats.level >= currentEnemyLevel)
                    {
                        playerCanBeat= true;
                        playerLevelManager.GainEnemyLevel(currentEnemyLevel);
                        playerAnimationChanger.PlayerPunchAnim();
                        playerMovement.SpeedDuringFight();
                        
                    }
                    else
                    {
                        enemyCanBeat= true;
                        playerMovement.SpeedDuringFight();
                    }
                }
                

            }
        }
        void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Enemy"))
            {
                currentEnemyLevel= 0;
                playerCanBeat= false;
                playerMovement.FollowingSpeed();
                
            }
        }
    }
}