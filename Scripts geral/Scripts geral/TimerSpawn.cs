using UnityEngine;
using System.Collections;

public class SceneTimer : MonoBehaviour
{
    public float tempoLimite = 30f; // tempo até parar spawn e destruir portais

    void Start()
    {
        StartCoroutine(EncerrarCena());
    }

    IEnumerator EncerrarCena()
    {
        yield return new WaitForSeconds(tempoLimite);

        // Para todos os spawners de inimigos
        SpawnsInimigo[] spawners = Object.FindObjectsByType<SpawnsInimigo>(FindObjectsSortMode.None);
        foreach (SpawnsInimigo s in spawners)
        {
            s.enabled = false;
        }

        // Destroi todos os objetos com tag "Portal"
        GameObject[] portais = GameObject.FindGameObjectsWithTag("Portal");
        foreach (GameObject portal in portais)
        {
            Destroy(portal);
        }

        Debug.Log("Spawn parado e portais destruídos após " + tempoLimite + " segundos.");
    }
}


