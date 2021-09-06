using UnityEngine;

public sealed class Background : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        var gameCamera = GameCamera.instance;
        var maxY = gameCamera.myCamera.orthographicSize;
        var maxX = maxY * gameCamera.myCamera.aspect;

        var spriteExtents = (Vector2)spriteRenderer.sprite.bounds.extents;
        var scaleX = maxX / spriteExtents.x;
        var scaleY = maxY / spriteExtents.y;
        var scale = Mathf.Max(scaleX, scaleY);

        transform.localScale = new Vector3(scale, scale, 1.0f);
    }
}
