using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] float chunkLength = 50f; 
    [SerializeField] int chunksOnScreen = 4;
    [SerializeField] Transform player;

    Queue<GameObject> activeChunks = new Queue<GameObject>();
    float nextSpawnZ = 0f;

    void Start()
    {
        for (int i = 0; i < chunksOnScreen; i++)
            SpawnChunk();
    }

    void Update()
    {
        GameObject oldest = activeChunks.Peek();
        if (player.position.z > oldest.transform.position.z + chunkLength)
            RecycleOldestChunk();
    }

    void SpawnChunk()
    {
        GameObject prefabToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        GameObject chunk = Instantiate(prefabToSpawn, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        activeChunks.Enqueue(chunk);
        nextSpawnZ += chunkLength;
    }

    void RecycleOldestChunk()
    {
        GameObject chunk = activeChunks.Dequeue();
        Destroy(chunk);
        SpawnChunk();
    }
}
