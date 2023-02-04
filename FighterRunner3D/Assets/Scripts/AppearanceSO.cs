using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New AppearanceSO")]
public class AppearanceSO : ScriptableObject
{
    [SerializeField] public Material[] materials;
    [SerializeField] public Vector3[] sizes;
}
