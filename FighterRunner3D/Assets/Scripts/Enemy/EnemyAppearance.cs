using UnityEngine;

namespace FR.Enemy
{
    [RequireComponent(typeof(LevelHolder))]
    public class EnemyAppearance : MonoBehaviour
    {
        [SerializeField] AppearanceSO appearance;

    }
}