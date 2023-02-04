using UnityEngine;
using FR.Player;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas startScreen;
    [SerializeField] PlayerMovement playerMovement;

    public bool isGameStarted;
   public void OnGameStart()
    {
        isGameStarted = true;
        startScreen.enabled = false;
        playerMovement.StartFollow();
    }
}
