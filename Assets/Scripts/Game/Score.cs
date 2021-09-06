using UnityEngine;
using TMPro;

public sealed class Score : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public int scorePerAsteroid = 50;

    private int score = 0;

    private void Awake()
    {
        Asteroid.OnDestroyed += OnAsteroidDestroyed;
        scoreLabel.text = score.ToString();
    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        score += scorePerAsteroid;
        scoreLabel.text = score.ToString();
    }
}
