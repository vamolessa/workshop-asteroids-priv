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
        var destroyDelayInSeconds = player.destroyFxPrefab.GetDurationInSeconds();
        StartCoroutine(GameOverCoroutine(destroyDelayInSeconds));
    }

    private IEnumerator GameOverCoroutine(float destroyDelayInSeconds)
    {
        yield return new WaitForSeconds(destroyDelayInSeconds + loadTitleScreenDelayInSeconds);
        SceneManager.LoadScene("Title");
    }
}
