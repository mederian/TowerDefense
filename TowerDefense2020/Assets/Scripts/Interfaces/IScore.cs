using UnityEngine;
public interface IScore
{
    int Xp { get; set; }
    int Kills { get; set; }

    GameObject GameObject { get; }
}
