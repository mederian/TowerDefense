using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IScore
{
    private int xp;
    private int level;
    private int kills;
    public int Xp { get => xp; set => xp = value; }
    public int Level { get => level; set => level = value; }
    public int Kills { get => kills; set => kills = value; }

    public GameObject GameObject => this.gameObject;
}
