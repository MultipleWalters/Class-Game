using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;

    private Vector2 screenZero;
    // Use this for initialization
    void Start()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }
        objectWidth = transform.GetComponent<CapsuleCollider>().radius;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        Debug.Log(screenBounds);
        transform.position = viewPos;
    }
}