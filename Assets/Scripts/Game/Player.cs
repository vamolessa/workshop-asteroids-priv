using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public Bullet bulletPrefab;

    public float acceleration = 1.0f;
    public float maxVelocity = 10.0f;
    public float angularVelocity = 60.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.AddForce(transform.up * acceleration, ForceMode.Acceleration);

            float velocity = myRigidbody.velocity.magnitude;
            if (velocity > maxVelocity)
                myRigidbody.velocity *= maxVelocity / velocity;
        }

        if (Input.GetKey(KeyCode.A))
            myRigidbody.rotation *= Quaternion.Euler(0.0f, 0.0f, angularVelocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            myRigidbody.rotation *= Quaternion.Euler(0.0f, 0.0f, -angularVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, myRigidbody.position, Quaternion.identity);
            bullet.Shoot(transform.up);
        }
    }
}
