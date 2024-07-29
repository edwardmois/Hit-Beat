using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText; // Reference to the Text element
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        if (scoreText == null)
        {
            Debug.LogError("ScoreText not assigned in the Inspector.");
        }

        // Initialize the score text
        UpdateScoreText();
    }

    void Update()
    {
        // Continuously update the score text
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (gameManager != null && scoreText != null)
        {
            scoreText.text = "Score: " + gameManager.score;
        }
    }
}
