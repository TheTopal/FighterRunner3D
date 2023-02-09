using System.Collections;
using UnityEngine;

namespace FR.Player
{
    public class PlayerAnimationChanger : MonoBehaviour
    {
        Animator playerAnimator;
        [SerializeField] AnimationClip playerPunchAnim;

        void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        public void PlayerRunningAnim()
        {
            playerAnimator.SetBool("isRunning", true);
        }
        public IEnumerator PlayerPunchAnimTimer()
        {
            playerAnimator.SetBool("isPunching", true);
            yield return new WaitForSeconds(playerPunchAnim.length);
            playerAnimator.SetBool("isPunching", false);
        }
        public void PlayerPunchAnim()
        {
            StartCoroutine(PlayerPunchAnimTimer());
        }

    }
}