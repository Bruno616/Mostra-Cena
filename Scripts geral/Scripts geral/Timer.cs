using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // necessário para trocar de cena

public class SimpleCountdown : MonoBehaviour
{
    public float startTime = 60f; // tempo inicial em segundos
    public TextMeshProUGUI timerText;
    public string victorySceneName = "VictoryScene"; // nome da cena de vitória

    private float timeLeft;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) timeLeft = 0;
        }
        else
        {
            SceneManager.LoadScene(victorySceneName);
        }

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
