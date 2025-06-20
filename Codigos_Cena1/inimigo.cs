using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Velocidade do inimigo.")]
    public float speed = 2f;

    void Update()
    {
        // Move o inimigo para frente (em sua direção local)
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
