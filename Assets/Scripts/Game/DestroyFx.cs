using UnityEngine;

public sealed class DestroyFx : MonoBehaviour
{
    public AudioSource destroyAudioSource;
    public ParticleSystem myParticleSystem;

    public float GetDurationInSeconds()
    {
        var audioDurationInSeconds = destroyAudioSource.clip.length;
        var myParticleSystemDurationInSeconds = myParticleSystem.main.duration;

        var duration = Mathf.Max(
            audioDurationInSeconds,
            myParticleSystemDurationInSeconds
        );
        return duration;
    }

    private void Start()
    {
        var duration = GetDurationInSeconds();
        Destroy(gameObject, duration);
    }
}
