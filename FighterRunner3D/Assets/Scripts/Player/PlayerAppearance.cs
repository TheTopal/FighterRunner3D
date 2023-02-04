using UnityEngine;

namespace FR.Player
{
    public class PlayerAppearance : MonoBehaviour
    {
        [SerializeField] AppearanceSO appearance;    
        PlayerLevelManager playerLevelManager;
        Renderer _renderer;
        Transform _playerScale;

        void Awake()
        {
           _renderer = GetComponentInChildren<Renderer>();
           playerLevelManager= GetComponent<PlayerLevelManager>();
           _playerScale= GetComponent<Transform>();
        }

        void FixedUpdate()
        {
            DetermineAppearance();
        }

        void DetermineAppearance()
        {
            _renderer.material = appearance.materials[playerLevelManager._levelCounter];
            _playerScale.localScale = appearance.sizes[playerLevelManager._levelCounter];
        }
    }
}