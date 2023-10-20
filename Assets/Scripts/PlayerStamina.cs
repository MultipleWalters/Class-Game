using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    
    /// <summary>
    /// Maximum number of Stamina points for each player.
    /// </summary>
    public int staminaPoints;
    /// <summary>
    /// Regeneration Interval. Counted in frames.
    /// </summary>
    public int regenerationInterval;
    public int regenerationRate;
    /// <summary>
    /// Regeneration Delay duration after being hit. Counted in frames.
    /// </summary>
    public int regenerationDelay;
    public int staminaLostOnAction;
    public int staminaPenalty;
    public int staminaRestored;
    
    private int currentTime;
    private int currentStamina;
    private bool shouldRegenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = staminaPoints;
        currentTime = regenerationInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina < 0)
            currentStamina = 0;
        if (currentStamina > staminaPoints)
            currentStamina = staminaPoints;
        
        if (shouldRegenerate && currentStamina < staminaPoints)
            RegenerateStamina();

        //Testing
        if (Input.GetKeyDown(KeyCode.PageDown))
            LoseStamina(staminaLostOnAction);

        if (Input.GetKeyDown(KeyCode.End))
        {
            LoseStamina(staminaLostOnAction + staminaPenalty);
            currentTime = regenerationInterval + regenerationDelay;
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
            GainStamina(staminaRestored);

    }

    void RegenerateStamina()
    {
        currentTime -= 1;
        if (currentTime <= 0)
        {
            GainStamina(regenerationRate);
        }
    }

    void LoseStamina(int staminaLost)
    {
        currentStamina -= staminaLost;
        //Testing
        print("Stamina Lost. Current Stamina: " + currentStamina);
    }

    void GainStamina(int staminaGained)
    {
        currentStamina += staminaGained;
        currentTime = regenerationInterval;
        //Testing
        print("Stamina Gained. Current Stamina: " + currentStamina);

    }
}
