using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Tooltip("Velocidade do inimigo.")]
    public float speed = 2f;

    void Update()
    {
        // Move o inimigo para frente (em sua direção local negativa do Z)
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
