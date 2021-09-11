using UnityEngine;

public sealed class Asteroid : MonoBehaviour
{
    public static System.Action<Asteroid> OnSpawned;
    public static System.Action<Asteroid> OnDestroyed;

    public Rigidbody2D myRigidbody;
    public Asteroid smallerAsteroidPrefab;
    public int smallerAsteroidSpawnCount = 3;
    public DestroyFx destroyFxPrefab;

    public float cameraShakeStrengh = 0.01f;
    public int cameraShakeCount = 20;

    public float minInitialVelocity = 1.0f;
    public float maxInitialVelocity = 8.0f;

    public float minRotationVelocity = 20.0f;
    public float maxRotationVelocity = 90.0f;

    private float rotationVelocity;

    private void Start()
    {
        var initialVelocity = Random.Range(minInitialVelocity, maxInitialVelocity);
        var initialDirection = Random.insideUnitCircle.normalized;
        myRigidbody.velocity = initialDirection * initialVelocity;

        rotationVelocity = Random.Range(minRotationVelocity, maxRotationVelocity);
        if (Random.value > 0.5f)
        {
            rotationVelocity = -rotationVelocity;
        }

        if (OnSpawned != null)
        {
            OnSpawned(this);
        }
    }

    private void OnDestroy()
    {
        if (OnDestroyed != null)
        {
            OnDestroyed(this);
        }
    }

    private void Update()
    {
        myRigidbody.rotation += rotationVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var bullet = collider.GetComponent<Bullet>();
        if (bullet != null)
        {
            for (var i = 0; i < smallerAsteroidSpawnCount; i++)
            {
                Instantiate(smallerAsteroidPrefab, myRigidbody.position, Quaternion.identity);
            }

            GameCamera.instance.Shake(cameraShakeStrengh, cameraShakeCount);
            Instantiate(destroyFxPrefab, myRigidbody.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
