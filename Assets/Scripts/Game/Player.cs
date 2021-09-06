using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Bullet bulletPrefab;

    public float movementForce = 1.0f;
    public float maxVelocity = 10.0f;
    public float angularVelocity = 60.0f;
    public float shootCooldownInSeconds = 0.5f;
    public float shootCameraShakeStrenght = 0.02f;
    public int shootCameraShakeCount = 5;

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

            GameCamera.instance.Shake(shootCameraShakeStrenght, shootCameraShakeCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("epaa!!");
    }
}
