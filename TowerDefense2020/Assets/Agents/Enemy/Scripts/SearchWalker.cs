using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyWalker))]
public class SearchWalker : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private EnemyWalker walker;
    // Start is called before the first frame update
    void Start()
    {
        walker = GetComponent<EnemyWalker>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            walker.MoveTowards(target.transform.position);
        }
    }
}
