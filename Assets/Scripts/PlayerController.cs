using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    private float acceleration = 0;
    public float baseAcceleration = 100;
    private float curVelocity = 0;
    private Vector2 moving = Vector2.zero;

    public float dashDistance = 0;
    public float dashTime = 0;
    private float curDashDistance = 0;
    private bool dashing = false;
    private float dashingDirection = 0;

    private Hitbox hb;


    private void Start()
    {
        acceleration = baseAcceleration;

        hb = GetComponent<Hitbox>();
    }

    private void Update()
    {
        Dashing();
        
        if(moving.x != 0)
        {
            acceleration = Mathf.Sign(moving.x) * baseAcceleration;
            curVelocity += acceleration * Time.deltaTime;
            if (Mathf.Abs(curVelocity) > maxSpeed)
                curVelocity = maxSpeed * Mathf.Sign(acceleration);
        }
        else
        {
            curVelocity -= acceleration * Time.deltaTime;
            if (Mathf.Sign(curVelocity) !=  Mathf.Sign(acceleration))
                   curVelocity = 0;
        }

        transform.Translate(new Vector3(1, 0, 0) * curVelocity * Time.deltaTime);
        hb.UpdateCollision();
    }

    public void Move(InputAction.CallbackContext callBack)
    {
        moving = callBack.ReadValue<Vector2>();
    }

    public void Dash(InputAction.CallbackContext callBack)
    {
        dashing = Mathf.Abs(callBack.action.ReadValue<float>()) > 0.6;
        dashingDirection = Mathf.Sign(callBack.action.ReadValue<float>());
        var axisVal = callBack.ReadValue<float>();
        Debug.Log(axisVal);
    }

    public void Dashing()
    {
        if (dashing)
        {
            curDashDistance += dashDistance * Time.deltaTime / dashTime;
            transform.position += new Vector3(dashingDirection * (dashDistance * Time.deltaTime / dashTime), 0, 0);

            dashing = dashDistance > curDashDistance;
            if(!dashing)
                curDashDistance = 0;
        }
    }
}
 