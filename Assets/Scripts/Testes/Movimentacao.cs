using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float velocidade = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Lembra de fisica?
        // velocidade = variacao de posição / variacao de tempo
        // variacao de posição = velocidade * variacao de tempo
        float variacaoDeTempo = Time.deltaTime;
        Vector3 vetorVelocidade = new Vector3(velocidade, 0.0f, 0.0f);
        Vector3 variacaoDePosicao = vetorVelocidade * variacaoDeTempo;
        transform.position += variacaoDePosicao;
    }
}
