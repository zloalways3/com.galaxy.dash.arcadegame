using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _goldCoinPrefab;
    [SerializeField] private GameObject[] _globePrefab;
    private float spawnInterval = 0.1f; 
    private int coinSpawnChance = 80; 

    private void Start()
    {
        InvokeRepeating("EntitySpawn", 0f, spawnInterval);
    }

    private void EntitySpawn()
    {
        int rndValue = Random.Range(0, 100);

        if (rndValue < coinSpawnChance)
        {
            SpawnCoin();
        }
        else
        {
            CreateSphereInstance();
        }
    }

    private void SpawnCoin()
    {
        var goldCoin = Instantiate(_goldCoinPrefab, GenerateRandomSpawnPoint(), Quaternion.identity);
        goldCoin.transform.parent = transform.parent;
    }

    private void CreateSphereInstance()
    {
        var orb = Instantiate(_globePrefab[Random.Range(0,_globePrefab.Length)], GenerateRandomSpawnPoint(), Quaternion.identity);
        orb.transform.parent = transform.parent;
    }

    private Vector3 GenerateRandomSpawnPoint()
    {
        float horizontalCoord = Random.Range(-8f, 8f);
        float verticalCoord = Random.Range(-4f, 4f);
        return new Vector3(horizontalCoord, verticalCoord, 0);
    }
}