using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidwardBullet : Enemy
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Death();
    }
    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
