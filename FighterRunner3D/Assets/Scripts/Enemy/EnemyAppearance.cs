using UnityEngine;

namespace FR.Enemy
{
    [RequireComponent(typeof(LevelHolder))]
    public class EnemyAppearance : MonoBehaviour
    {
        [SerializeField] AppearanceSO appearance;
        LevelHolder levelHolder;
        Renderer _renderer;
        Transform _enemyScale;
        [SerializeField] int stageOfLevel;
        float _levelDivider = 0.05f;

        void Awake()
        {
            levelHolder = GetComponent<LevelHolder>();
            _renderer = GetComponentInChildren<Renderer>();
            _enemyScale = GetComponent<Transform>();
        }
        private void Start()
        {
            DetermineEnemyAppearance();
        }

        void DetermineEnemyAppearance()
        {
            stageOfLevel = Mathf.RoundToInt((float)levelHolder.enemyLevel * _levelDivider);
            _renderer.material = appearance.materials[stageOfLevel];
            _enemyScale.localScale = appearance.sizes[stageOfLevel];
        }
    }
}