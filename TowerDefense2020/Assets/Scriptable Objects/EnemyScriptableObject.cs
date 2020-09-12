using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ResourceID", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]

public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;
    public GameObject meshObject;
    public float hp;
}
