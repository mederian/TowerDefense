using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IAgent
{
    [SerializeField] private GameObject meshObject;

    public GameObject MeshObject { get => meshObject; set => meshObject = value; }



}
