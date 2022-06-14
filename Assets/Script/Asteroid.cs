using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float AsteroidHealth = 100f;
    private float RotateSpeed = 0.05f;
    private float Radius = 3f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {

        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime); 

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
