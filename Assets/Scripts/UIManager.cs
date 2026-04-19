using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text shadowCountText;

    public AudioSource musicSource;
    public float pitchMax = 1.5f;

    void Start()
    {
        // Garante que o painel comece desligado
        if (endGamePanel != null) endGamePanel.SetActive(false);
        
        // Garante que a música comece na velocidade normal
        if (musicSource != null) musicSource.pitch = 1f;
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
            GameController.timeLeft -= Time.deltaTime;
            timerText.text = "Tempo: " + GameController.timeLeft.ToString("f0") + "s";
            scoreText.text = "Moedas: " + GameController.score;

            int currentShadows = FindObjectsByType<EnemyShadow>(FindObjectsSortMode.None).Length;
            shadowCountText.text = "Inimigos: " + currentShadows;

            if (musicSource != null && GameController.timeLeft <= 10f)
            {
                float progress = 1f - (GameController.timeLeft / 10f);
                musicSource.pitch = Mathf.Lerp(1f, pitchMax, progress);
            }
        }
        else if (!endGamePanel.activeSelf)
        {
            GameController.timeLeft = 0;
            timerText.text = "Time: 0s";
            finalScoreText.text = "Moedas coletadas: " + GameController.score;
            
            endGamePanel.SetActive(true);

            if (musicSource != null) musicSource.Stop();
        }
    }
}