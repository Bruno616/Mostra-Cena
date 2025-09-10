using UnityEngine;

public class Barriera : MonoBehaviour
{
    [Header("Barreira")]
    [SerializeField] private int dano = 1; 
    [SerializeField] private bool destruirInimigo = true; // 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (destruirInimigo)
            {
                Destroy(other.gameObject); // destrói o inimigo
            }

            if (GameManager.instance != null)
            {
                GameManager.instance.TakeDamage(dano); // aplica dano ao player
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado na cena!");
            }
        }
    }
}
