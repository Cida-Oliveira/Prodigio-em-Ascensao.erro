using UnityEngine;

public class PFlutuante : MonoBehaviour
{

    public float distancia = 3f;
    public float velocidade = 2f;

    private Vector3 posicao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Mathf.PingPong(Time.time * velocidade, distancia) - (distancia / 2);
        transform.position = posicao + new Vector3(movimento, 0f, 0f);
    }
}
