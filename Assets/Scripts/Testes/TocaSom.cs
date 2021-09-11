using UnityEngine;

public class TocaSom : MonoBehaviour
{
    public AudioSource meuAudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            meuAudioSource.Play();
        }
    }
}
