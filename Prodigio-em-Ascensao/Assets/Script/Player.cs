using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade; //declaração de uma variável pública para controlar a velocidade do movimento do player

    public float jumpForce; //força do pulo 
    public bool isJump; //indica se o personagem esta no ar
    public bool doubleJump; //indica se o personagem pode realizar um segundo pulo

    private Rigidbody2D rig; //referencia rigidbody para aplicar fisica

    private GameObject coinColetar;


    void Start()
    {
        //pega o componente Rigidbody2D anexado ao GameObject
        rig = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    private void Update()
    {

        Move(); //chama o método Move a cada frame para atualizar o movimento do player

        Jump(); //chama o metodo jump a cada frame

        if (Input.GetKeyDown(KeyCode.W) && coinColetar != null)
        {
            CollectCoin();
        }
    }

    [System.Obsolete]
    private void Move() // Esse método aqui cuida do movimento do personagem.

    {
        // Aqui a gente pega o input do teclado: seta esquerda, seta direita, A ou D.
        // GetAxisRaw é mais direto – retorna -1 se for pra esquerda, 1 pra direita e 0 se nada for pressionado.
        float input = Input.GetAxisRaw("Horizontal");

        // com esse valor de input, a gente aplica uma velocidade no Rigidbody
        // isso garante que o movimento siga as regras da física do Unity
        rig.velocity = new Vector2(input * velocidade, rig.velocity.y);

        // se o jogador estiver apertando pra direita...
        if (input > 0f)
        {
            // ...fazemos o personagem olhar pra frente (direita)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        // se o jogador estiver apertando pra esquerda...
        else if (input < 0f)
        {
            // ...viramos ele pra esquerda (gira no eixo Y)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }


    void Jump() //é chamado quando o jogador clicar espaço (tentar pular)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump == false)
            {
                //aplica força para cima, primeiro pulo
                rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true; //permite o segundo pulo
                isJump = true; //marca como no ar
            }

            else
            {
                //se já esta no ar e o duplo pulo esta liberado
                if (doubleJump)
                {
                    //executa o segundo pulo
                    rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false; //não pode mais pular
                }
            }
        }
    }

    // Detecta quando o personagem toca no chão
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão"))
        {
            isJump = false;
            doubleJump = false; // reseta o double jump ao tocar no chão
        }
    }


    // Detecta quando o personagem sai do chão e da plataforma
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão"))
        {
            isJump = true;
        }
    }

    private void CollectCoin()
    {
        Destroy(coinColetar);
        coinColetar = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinColetar = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coin") && other.gameObject == coinColetar)
        {
            coinColetar = null;
        }
    }
}