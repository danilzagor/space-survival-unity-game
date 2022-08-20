using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmebaEnemy : Enemy
{
    
    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
