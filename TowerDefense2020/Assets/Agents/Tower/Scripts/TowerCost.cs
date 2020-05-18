using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCost : MonoBehaviour
{
    [SerializeField] private int goldCost = 0;
    [SerializeField] private int fireCost = 0;
    [SerializeField] private int frostCost = 0;
    [SerializeField] private int poisonCost = 0;
    [SerializeField] private int manaCost = 0;

    public int GoldCost { get => goldCost; set => goldCost = value; }
    public int FireCost { get => fireCost; set => fireCost = value; }
    public int FrostCost { get => frostCost; set => frostCost = value; }
    public int PoisonCost { get => poisonCost; set => poisonCost = value; }
    public int ManaCost { get => manaCost; set => manaCost = value; }

}
