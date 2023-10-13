using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private RectTransform hitbox;
    [SerializeField] private Camera gameplayCamera;
    private Canvas cv;
    private RectTransform canvasRect;

    private void Start()
    {
        cv = hitbox.GetComponentInParent<Canvas>();
        canvasRect = cv.GetComponent<RectTransform>();
    }

    public void UpdateCollision()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(gameplayCamera, transform.position);
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, cv.renderMode == RenderMode.ScreenSpaceOverlay ? null : gameplayCamera, out result);


        hitbox.anchoredPosition = result;

    }    
}
