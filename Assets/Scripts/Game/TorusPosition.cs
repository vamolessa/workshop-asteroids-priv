using UnityEngine;

public sealed class TorusPosition : MonoBehaviour
{
    public const float MARGIN = 0.5f;

    public Rigidbody myRigidbody;
    public Camera camera;

    private void Update()
    {
        var myPosition = myRigidbody.position;
        var cameraPosition = camera.transform.position;
        cameraPosition.z = myPosition.z;

        var positionInCamera = myPosition - cameraPosition;

        var maxX = camera.orthographicSize * camera.aspect + MARGIN;
        var maxY = camera.orthographicSize + MARGIN;

        if (myPosition.x > maxX)
            myPosition.x = -maxX;
        if (myPosition.x < -maxX)
            myPosition.x = maxX;

        if (myPosition.y > maxY)
            myPosition.y = -maxY;
        if (myPosition.y < -maxY)
            myPosition.y = maxY;

        myRigidbody.position = myPosition + cameraPosition;
    }
}
