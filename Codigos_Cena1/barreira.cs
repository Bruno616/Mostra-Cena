using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string enemyTag = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
        }
    }
}
