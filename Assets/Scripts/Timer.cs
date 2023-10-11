using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 60.0f; // Total time in seconds

    private float currentTime;
    private bool isCounting = false;

    private void Start()
    {
        isCounting = true;
        currentTime = totalTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0.0f)
            {
                // Timer has reached zero, you can add your desired logic here
                currentTime = 0.0f;
                isCounting = false;
            }
        }
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
