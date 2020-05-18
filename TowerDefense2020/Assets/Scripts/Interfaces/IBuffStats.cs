using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffStats
{
    float BuffDamage { get; set; }
    float BuffRange { get; set; }
    float BuffFireCoolDown { get; set; }
    float BuffAoe { get; set; }
    float BuffSlow { get; set; }
    float BuffDot { get; set; }
}
