using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public sealed class TitleScreen : MonoBehaviour
{
    public TMP_Text pressButtonToStartLabel;
    public float pressButtonBlinkDurationInSeconds = 0.5f;

    private IEnumerator Start()
    {
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
