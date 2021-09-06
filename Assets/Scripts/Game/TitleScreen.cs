using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public sealed class TitleScreen : MonoBehaviour
{
    public TMP_Text pressButtonToStartLabel;
    public float pressButtonBlinkDurationInSeconds = 0.5f;
    public CanvasGroup bestScoreGroup;
    public TMP_Text bestScoreText;

    private IEnumerator Start()
    {
        bestScoreGroup.alpha = 0.0f;
        var bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (bestScore > 0)
        {
            bestScoreGroup.alpha = 1.0f;
            bestScoreText.text = bestScore.ToString();
        }

        var wait = new WaitForSeconds(pressButtonBlinkDurationInSeconds);

        for (; ; )
        {
            pressButtonToStartLabel.enabled = true;
            yield return wait;
            pressButtonToStartLabel.enabled = false;
            yield return wait;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
