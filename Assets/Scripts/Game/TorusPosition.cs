using UnityEngine;

public sealed class TorusPosition : MonoBehaviour
{
    public const float MARGIN = 0.5f;

    public Rigidbody2D myRigidbody;

    private void FixedUpdate()
    {
        var gameCamera = GameCamera.instance;
        var myPosition = myRigidbody.position;
        var cameraPosition = (Vector2)gameCamera.transform.position;

        var positionInCamera = myPosition - cameraPosition;

        var maxX = gameCamera.myCamera.orthographicSize * gameCamera.myCamera.aspect + MARGIN;
        var maxY = gameCamera.myCamera.orthographicSize + MARGIN;

        if (myPosition.x > maxX)
        {
            myPosition.x = -maxX;
        }
        if (myPosition.x < -maxX)
        {
            myPosition.x = maxX;
        }

        if (myPosition.y > maxY)
        {
            myPosition.y = -maxY;
        }
        if (myPosition.y < -maxY)
        {
            myPosition.y = maxY;
        }

        myRigidbody.position = myPosition + cameraPosition;
    }
}
