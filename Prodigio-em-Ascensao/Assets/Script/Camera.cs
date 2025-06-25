using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float timeLerp;

    private void FixedUpdate()
    {
        // Segue o jogador no X e Y, mantendo a câmera atrás no Z
        Vector3 targetPosition = player.position + new Vector3(0, 0, -10);

        // Faz uma transição suave da posição atual para a nova
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, timeLerp);

        // Limita o X dentro dos valores definidos
        float clampedX = Mathf.Clamp(smoothPosition.x, minX, maxX);

        // Aplica a nova posição com o Y do jogador e o X limitado
        transform.position = new Vector3(clampedX, smoothPosition.y, smoothPosition.z);
    }
}
