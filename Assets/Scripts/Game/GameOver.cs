using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameOver : MonoBehaviour
{
    public float loadTitleScreenDelayInSeconds = 1.0f;

    private void Awake()
    {
        Player.OnDestroyed += OnPlayerDestroyed;
    }

    private void OnDestroy()
    {
        Player.OnDestroyed -= OnPlayerDestroyed;
    }

    private void OnPlayerDestroyed(Player player)
    {
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(loadTitleScreenDelayInSeconds);
        SceneManager.LoadScene("Title");
    }
}
