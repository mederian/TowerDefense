using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private GameObject meshObject;

    public GameObject MeshObject { get => meshObject; set => meshObject = value; }
    // Start is called before the first frame update


}
