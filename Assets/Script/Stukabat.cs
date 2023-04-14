using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stukabat : Enemy
{
    [SerializeField] private float RotateSpeed = 0.05f;
    [SerializeField] private float Radius = 1.5f;
    private Vector2 _centre;
    private float _angle;
    bool isInScream=false;
    protected override void Start()
    {
        base.Start();       
    }
    protected override void FixedUpdate()
    {
        direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

            
            if (direction.magnitude <= distanceToAttack && direction.magnitude >= 3)
            {
                IsInAttack();
                FindWay(direction);
            }

            if (direction.magnitude <= 3)
            {                            
                Invoke("ScreamAttack", 5f);
            }
            if (isInScream==false && direction.magnitude <= 10)
            {
                MakeACircle();
            }
        }
    }
    private void MakeACircle()
    {
        _centre = player.PlayerGameObject.transform.position;
        _angle -= RotateSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime*50+180);
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
    private void ScreamAttack()
    {
        isInScream = true;
        CancelInvoke("ScreamAttack");
        GetComponent<Animator>().Play("StukabatScream");
        player.PlayerHealth -= 10;
        GetComponent<Animator>().Play("StukabatFly");
        Invoke("BoolIsInScream", 0.5f);
    }
    private void BoolIsInScream()
    {
        isInScream = false;
    }
}
