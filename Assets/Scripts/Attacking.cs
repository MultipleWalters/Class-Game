using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    bool kicking;
    bool punching;
    Hitbox playerHitbox;
    public float currentAttackTime;
    public float attackFrames;
    public Transform hurtBoxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        playerHitbox = GetComponent<Hitbox>();
    }

    // Update is called once per frame
    void Update()
    {                           
        currentAttackTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentAttackTime = attackFrames;
            if(currentAttackTime >= 0)
            {
                kicking = true;
                playerHitbox.CreateHurtbox();
            }
            else
            {
                playerHitbox.DestroyHurtbox();
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            currentAttackTime = attackFrames;
            if (currentAttackTime >= 0)
            {
                kicking = true;
                playerHitbox.CreateHurtbox();
            }
            else
            {
                playerHitbox.DestroyHurtbox();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hitbox enemyHitbox = other.gameObject.GetComponent<Hitbox>();
        PlayerStamina enemyStamina = other.gameObject.GetComponent<PlayerStamina>();
        if (enemyHitbox.isDefending = true && !kicking)
        {
            return;
        }
        else
        {
            enemyStamina.LoseStamina(1);
        }
    }

}
