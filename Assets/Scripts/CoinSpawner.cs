using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform playerTransform;
    
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;

    public float minDistanceFromPlayer = 5f;
    public float minDistanceFromOtherCoins = 3f;

    public void SpawnNewCoin()
    {
        Vector2 spawnPos = Vector2.zero;
        bool isValidPos = false;
        int attempts = 0;

        while (!isValidPos && attempts < 50)
        {
            attempts++;
            spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            float distToPlayer = Vector2.Distance(spawnPos, playerTransform.position);
            if (distToPlayer < minDistanceFromPlayer) continue;

            Collider2D otherCoin = Physics2D.OverlapCircle(spawnPos, minDistanceFromOtherCoins);
            if (otherCoin != null && otherCoin.CompareTag("Moeda")) continue;

            isValidPos = true;
        }

        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}
