using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public float velocity = 10.0f;
    public float durationInSeconds = 1.0f;

    public void Shoot(Vector2 direction)
    {
        myRigidbody.velocity = direction * velocity;
        Destroy(gameObject, durationInSeconds);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
