using FR.Player;
using System.Collections;
using UnityEngine;

namespace FR.Enemy
{
    public class EnemyAnimationChanger : MonoBehaviour
    {
        Animator enemyAnimator;
        [SerializeField] AnimationClip enemyPunchAnim;
        [SerializeField] Combat playerCombat;

        void Awake()
        {
            enemyAnimator = GetComponent<Animator>();    
        }
        void Update()
        {
            if(playerCombat.enemyCanBeat) 
            {
                EnemyPunchAnimation();
                playerCombat.enemyCanBeat = false;
            }    
        }
        public IEnumerator EnemyAnimationTimer()
        {
            enemyAnimator.SetBool("isEnemyPunching", true);
            yield return new WaitForSeconds(enemyPunchAnim.length);
            enemyAnimator.SetBool("isEnemyPunching", false);
        }
        public void EnemyPunchAnimation()
        {
            StartCoroutine(EnemyAnimationTimer());
        }


    }
}