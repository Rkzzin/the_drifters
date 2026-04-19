using UnityEngine;

public class ShadowSpawner : MonoBehaviour
{
    public GameObject shadowPrefab;
    public float spawnInterval = 7f;
    
    public float baseDelay = 2f;
    public float delayIncrement = 0.5f;
    
    private float nextSpawnTime;
    private int shadowsSpawned = 0;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (!GameController.gameOver && Time.time >= nextSpawnTime)
        {
            SpawnShadow();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnShadow()
    {
        GameObject newShadow = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
        
        EnemyShadow shadowScript = newShadow.GetComponent<EnemyShadow>();
        
        if (shadowScript != null)
        {
            shadowScript.delaySeconds = baseDelay + (shadowsSpawned * delayIncrement);
            shadowsSpawned++;
        }
        
    }
}