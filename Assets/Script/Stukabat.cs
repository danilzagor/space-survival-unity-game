using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stukabat : Enemy
{
    [SerializeField] private float RotateSpeed = 0.05f;
    [SerializeField] private float Radius = 3f;
    private Vector2 _centre;
    private float _angle;
    protected override void FixedUpdate()
    {
        /*direction = playerTransform.position - transform.position;
        if (direction.magnitude <= distanceToAttack)
        {

            
            if (direction.magnitude <= distanceToAttack && direction.magnitude >= 3)
            {
                IsInAttack();
                FindWay(direction);
            }

            if (direction.magnitude <= 3)
            {
                MakeACircle();
            }
        }*/
        MakeACircle();
    }
    private void MakeACircle()
    {
        _centre = player.PlayerGameObject.transform.position;
        _angle += RotateSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.AngleAxis(_angle * 10, Vector3.forward);
        var offset = new Vector2(Mathf.Sin(_angle * 10 /20), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
