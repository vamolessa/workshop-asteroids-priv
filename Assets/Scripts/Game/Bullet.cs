using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    public Rigidbody myRigidbody;

    public float velocity = 10.0f;

    public void Shoot(Vector2 direction)
    {
        myRigidbody.velocity = direction * velocity;
    }
}
