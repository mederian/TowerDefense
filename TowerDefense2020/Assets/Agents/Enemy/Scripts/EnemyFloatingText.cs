using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyFloatingText : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    

    public void GenerateScoreText(float damage)
    {
        Vector3 v = new Vector3(transform.position.x, (transform.position.y + 1.5f), transform.position.z);
        GameObject go = Instantiate(textPrefab, v, textPrefab.transform.rotation);
        go.GetComponent<TextMeshPro>().SetText(damage.ToString());
    }
    public void GenerateScoreText(float damage, float initDamage)
    {
        Vector3 v = new Vector3(transform.position.x, (transform.position.y + 1.5f), transform.position.z);
        GameObject go = Instantiate(textPrefab, v, textPrefab.transform.rotation);
        go.GetComponent<TextMeshPro>().SetText(damage.ToString() + "(" + initDamage.ToString() + ")");
    }
}
