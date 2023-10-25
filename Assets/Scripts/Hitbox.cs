using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private RectTransform hitboxPrefab;
    [SerializeField] private Camera gameplayCamera;
    private RectTransform hitbox;
    [SerializeField] private RectTransform hurtbox;
    private Canvas cv;
    private RectTransform canvasRect;
    private Collider playerCollider;
    public bool isDefending;

    public Vector3 hitboxMin;
    public Vector3 hitboxMax;

    private void Awake()
    {
        playerCollider = GetComponent<Collider>();

        cv = FindObjectOfType<Canvas>();
        canvasRect = cv.GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (gameplayCamera == null)
        {
            gameplayCamera = Camera.main;
        }

        hitbox = Instantiate(hitboxPrefab, canvasRect);
    }

    public void UpdateCollision()
    {
        if (hitbox == null)
            return;
        hitboxMin = playerCollider.bounds.min;
        hitboxMin.z = transform.position.z;
        hitboxMax = playerCollider.bounds.max;
        hitboxMax.z = transform.position.z;

        Vector2 screenSpaceMin = TranslateToScreen(hitboxMin);
        Vector2 screenSpaceMax = TranslateToScreen(hitboxMax);
        
        hitbox.anchoredPosition = TranslateToScreen(transform.position);
        hitbox.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Abs(screenSpaceMax.x - screenSpaceMin.x));
        hitbox.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Abs(screenSpaceMax.y - screenSpaceMin.y));
    }

    public void CreateHurtbox()
    {
        if (hurtbox != null)
            return;
        
        hurtbox = Instantiate(hitboxPrefab, canvasRect);
        

    }

    public void DestroyHurtbox()
    {
        if (hurtbox != null)
            return;

        Destroy(hurtbox);
    }

    public Vector2 TranslateToScreen(Vector3 worldPos)
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(gameplayCamera, worldPos);
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, cv.renderMode == RenderMode.ScreenSpaceOverlay ? null : gameplayCamera, out result);

        return result;
    }
}
