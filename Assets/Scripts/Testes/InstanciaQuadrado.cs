using UnityEngine;

public class InstanciaQuadrado : MonoBehaviour
{
    public GameObject prefabQuadrado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject instanciaQuadrado =
                Instantiate(prefabQuadrado);

            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            instanciaQuadrado.transform.position =
                new Vector3(x, y, 0.0f);
        }
    }
}
