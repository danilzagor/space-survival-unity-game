using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Vector2 pointer;
    private RectTransform pointerRectTransform;
    [SerializeField] private Camera uiCamera;
    [SerializeField] private SpriteRenderer a;
    public GameObject Point;
    public GameObject pointWindow;
    [SerializeField] private Sprite Sprite;
    private void Start()
    {
        pointerRectTransform = GetComponent<RectTransform>();
        uiCamera = Camera.main;
        pointer = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
    }
    public void CreateNewPointer()
    {
        var newPoint = Instantiate(Point);
        newPoint.transform.SetParent(pointWindow.transform);
        newPoint.transform.localScale = Point.transform.localScale;
        newPoint.GetComponent<SpriteRenderer>().sprite = Sprite;
    }
    private void FixedUpdate()
    {
        CreateNewPointerProcces(pointer);
    }
    void CreateNewPointerProcces(Vector2 vector2)
    {

        Vector2 toPosition = vector2;
        Vector2 fromPosition = Camera.main.transform.position;
        Vector2 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) +270 % 360; //+270 degrees
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        Vector2 pointerPositionScreenPoint = Camera.main.WorldToScreenPoint(vector2);
        bool isOffScreen = pointerPositionScreenPoint.x <= 100f || pointerPositionScreenPoint.x >= Screen.width - 50f
            || pointerPositionScreenPoint.y <= 100f || pointerPositionScreenPoint.y >= Screen.height - 50f;
        if (isOffScreen)
        {
            a.color = new Color(1f, 1f, 1f, 1f);

            Vector2 cappedPointerScreenPosition = pointerPositionScreenPoint;
            if (cappedPointerScreenPosition.x <= 100f) cappedPointerScreenPosition.x = 100f;
            if (cappedPointerScreenPosition.x >= Screen.width - 50f) cappedPointerScreenPosition.x = Screen.width - 50f;
            if (cappedPointerScreenPosition.y <= 100f) cappedPointerScreenPosition.y = 100f;
            if (cappedPointerScreenPosition.y >= Screen.height - 50f) cappedPointerScreenPosition.y = Screen.height - 50f;

            pointerRectTransform.position = uiCamera.ScreenToWorldPoint(cappedPointerScreenPosition);
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, -3);
        }
        else a.color = new Color(1f, 1f, 1f, 0f);
    }

}
