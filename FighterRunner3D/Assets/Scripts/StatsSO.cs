using UnityEngine;

[CreateAssetMenu(menuName = "New StatSO")]
public class StatsSO : ScriptableObject
{
    
    [SerializeField] public int level = 1;


    public void GainLevel(int addLevel)
    {
        level += addLevel;
    }
   
}
