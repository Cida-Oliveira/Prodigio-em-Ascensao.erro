using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float timeLerp;

    private Player playerScript;
    private float yFixo = -0.5f;
    private bool liberarY = false;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    } 
    private void FixedUpdate()
    {
        if (playerScript.doubleJump)
        {
            liberarY = true;
        }

        float alvoY = liberarY ? player.position.y : yFixo;

        Vector3 targentPosition = new Vector3(player.position.x, alvoY, -10f);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, targentPosition, timeLerp);

        // Limita o X dentro dos valores definidos
        float clampedX = Mathf.Clamp(smoothPosition.x, minX, maxX);

        // Aplica a nova posição com o Y do jogador e o X limitado
        transform.position = new Vector3(clampedX, smoothPosition.y, smoothPosition.z);
    }
}
