using UnityEngine;

public class MudaCor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private bool mudou = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            mudou = !mudou;

        if (mudou)
            spriteRenderer.color = Color.red;
        else
            spriteRenderer.color = Color.white;
    }
}
