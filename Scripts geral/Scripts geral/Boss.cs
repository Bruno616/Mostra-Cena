using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab; // Prefab do boss
    [SerializeField] private float tempoParaSpawn = 5f; // tempo em segundos antes de spawnar

    private bool spawnou = false;

    void Start()
    {
        StartCoroutine(SpawnBossComDelay());
    }

    private IEnumerator SpawnBossComDelay()
    {
        yield return new WaitForSeconds(tempoParaSpawn);

        if (!spawnou && bossPrefab != null)
        {
            Instantiate(bossPrefab, transform.position, transform.rotation);
            spawnou = true;
        }
    }
}
