using UnityEngine;

public class ShooterRaycastGeneric : MonoBehaviour
{
    [Header("Configura��es do tiro")]
    public float range = 100f;                  // Alcance do tiro
    public KeyCode fireKey = KeyCode.Mouse0;    // Bot�o de tiro

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            Debug.LogWarning("Nenhuma c�mera com tag MainCamera encontrada!");
            return;
        }

        // Raio saindo do centro da tela (para combinar com a mira)
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        // Raycast detectando qualquer objeto com Collider
        if (Physics.Raycast(ray, out RaycastHit hit, range, ~0, QueryTriggerInteraction.Collide))
        {
            Debug.Log("Acertou: " + hit.collider.name);

            // Se o objeto tiver tag "Enemy", destr�i
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Inimigo destru�do!");
            }
        }
        else
        {
            Debug.Log("N�o acertou nada!");
        }
    }
}

