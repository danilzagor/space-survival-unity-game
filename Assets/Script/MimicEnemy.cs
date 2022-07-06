using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemy : Enemy
{
    [SerializeField] Sprite[] AnimationSprite;
    public override void MimicFunc()
    {
        if ((player.PlayerGameObject.position - transform.position).magnitude <= distanceToAttack)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[1];
        }
        else gameObject.GetComponent<SpriteRenderer>().sprite = AnimationSprite[0];
    }
    
}
