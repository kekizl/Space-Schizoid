using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startingTime = 0f; // Set the initial time remaining
    
    
    public static Timer Instance { get; private set; }

    public TextMeshProUGUI timerText; 
    private float timeElapsed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        string timeString = string.Format("Time Elapsed: {0:0}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }
}
    

