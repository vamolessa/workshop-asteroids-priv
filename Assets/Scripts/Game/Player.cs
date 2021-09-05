using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public float acceleration = 1.0f;
    public float maxVelocity = 10.0f;
    public float angularVelocity = 60.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(transform.up * acceleration, ForceMode.Acceleration);

            float velocity = playerRigidbody.velocity.magnitude;
            if (velocity > maxVelocity)
                playerRigidbody.velocity *= maxVelocity / velocity;
        }

        if (Input.GetKey(KeyCode.A))
            playerRigidbody.rotation *= Quaternion.Euler(0.0f, 0.0f, angularVelocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            playerRigidbody.rotation *= Quaternion.Euler(0.0f, 0.0f, -angularVelocity * Time.deltaTime);
    }
}
