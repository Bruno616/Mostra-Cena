using UnityEngine;

public class SpawnsInimigo : MonoBehaviour
{
    [Header("SpawnsInimigo")]
    public GameObject enemyPrefab;       // Prefab do inimigo
    public Transform[] spawnPoints;      // Pontos de spawn
    public float spawnInterval = 2f;     // Tempo entre spawns (segundos)

    private float timer;

    void Update()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Nenhum ponto de spawn atribuído!");
            return;
        }

        if (enemyPrefab == null)
        {
            Debug.LogWarning("Nenhum prefab de inimigo atribuído!");
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Escolhe um ponto de spawn aleatório
        int index = Random.Range(0, spawnPoints.Length);

        // Instancia o inimigo
        Instantiate(enemyPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
    }
}
