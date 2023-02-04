using UnityEngine;

namespace FR.Player
{
    public class PlayerLevelManager : MonoBehaviour
    {
        [SerializeField] StatsSO stats;
        Combat combat;
        int startingLevel = 1;  
        int _levelTransitionHelper = 0;
        int _levelDivider = 20;
        public int _levelCounter = 0;

        void Awake()
        {
            combat = GetComponent<Combat>();
            stats.level = startingLevel;
        }
       
        public void GainRegularGloveLevel(int gloveLevel)
        {
            stats.GainLevel(gloveLevel);
            LevelCounter(gloveLevel);
        }

        public void GainEnemyLevel(int enemyLevel)  //refered in FR.Player.Combat script.
        {
            if(combat.playerCanBeat)
            {
            stats.level += enemyLevel;
                LevelCounter(enemyLevel);
            } 
        }

        void LevelCounter(int addLevel)
        {
            for (int i = 0; i < 1; i+=addLevel)
            {   
                _levelTransitionHelper+= addLevel;
                if(_levelTransitionHelper % _levelDivider == 0)
                {
                    _levelCounter++;
                    if (_levelCounter > 6) { _levelCounter = 6; } //when the level cap increase we need to increase number 6.
                }         
            }
        }   
        
    }
}