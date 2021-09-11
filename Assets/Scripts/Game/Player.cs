using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public static System.Action<Player> OnDestroyed;

    [Header("Movement")]
    public Rigidbody2D myRigidbody;
    public AudioSource movementAudioSource;
    public float movementForce = 1.0f;
    public float maxVelocity = 10.0f;
    public float angularVelocity = 60.0f;

    [Header("Shoot")]
    public Bullet bulletPrefab;
    public AudioSource shootAudioSource;
    public float shootCooldownInSeconds = 0.5f;
    public float shootCameraShakeStrengh = 0.04f;
    public int shootCameraShakeCount = 5;

    [Header("Destroy")]
    public DestroyFx destroyFxPrefab;
    public float destroyCameraShakeStrengh = 0.02f;
    public int destroyCameraShakeCount = 20;

    private float lastShootTimestamp = Mathf.NegativeInfinity;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.AddForce(transform.up * movementForce, ForceMode2D.Force);

            float velocity = myRigidbody.velocity.magnitude;
            if (velocity > maxVelocity)
            {
                myRigidbody.velocity *= maxVelocity / velocity;
            }

            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }
        }
        else
        {
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.rotation += angularVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.rotation -= angularVelocity * Time.deltaTime;
        }
    }

    private void Update()
    {
        var timeNow = Time.time;
        if (Input.GetKeyDown(KeyCode.Space) && lastShootTimestamp + shootCooldownInSeconds < timeNow)
        {
            lastShootTimestamp = timeNow;
            var bullet = Instantiate(bulletPrefab, myRigidbody.position, Quaternion.identity);
            bullet.Shoot(transform.up);

            GameCamera.instance.Shake(shootCameraShakeStrengh, shootCameraShakeCount);
            shootAudioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (OnDestroyed != null)
        {
            OnDestroyed(this);
        }

        GameCamera.instance.Shake(destroyCameraShakeStrengh, destroyCameraShakeCount);
        Instantiate(destroyFxPrefab, myRigidbody.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
