using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParallaxEffect : MonoBehaviour
{
    /*private float hight, width, starposx, starposy;
    [SerializeField] private float parallaxEffect;
    private void Start()
    {
        starposx = transform.position.x;
        starposy = transform.position.y;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        hight = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Update()
    {
        float tempx = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float tempy = (Camera.main.transform.position.y * (1 - parallaxEffect));
        float distx = (Camera.main.transform.position.x * parallaxEffect);
        float disty = (Camera.main.transform.position.y * parallaxEffect);
        transform.position = new Vector2((starposx + distx) * Time.deltaTime, (starposy + disty) * Time.deltaTime);
        if (tempx > starposx + width) starposx += width;
        else if (tempx < starposx - width) starposx -= width;

        if (tempy > starposy + hight) starposy += hight;
        else if (tempy < starposy - hight) starposy -= hight;
    }*/
    /*[SerializeField] private RawImage _img;
    [SerializeField] private float  _x,_y;
    private void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }*/
    public Transform[] camadas;
    public float[] mult;
    private Vector3[] posOriginal;

    private void Awake()
    {
        posOriginal = new Vector3[camadas.Length];
        for(int i=0; i < camadas.Length; i++)
        {
            posOriginal[i] = camadas[i].position;
        }
    }
    private void Update()
    {
        for(int i=0; i < camadas.Length; i++)
        {
            camadas[i].position =  posOriginal[i]+mult[i] *( new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,camadas[i].position.z));
        }
    }
}
