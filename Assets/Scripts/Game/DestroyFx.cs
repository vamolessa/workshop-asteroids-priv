using UnityEngine;

public sealed class DestroyFx : MonoBehaviour
{
    public AudioSource destroyAudioSource;

    private void Start()
    {
        var audioDurationInSeconds = destroyAudioSource.clip.length;
        Destroy(gameObject, audioDurationInSeconds);
    }
}
