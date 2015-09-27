using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    public float spawnInterval = 0.5f;
    private float timeSinceLastSpawn = 0f;
    private float timePassed = 0f;

    public GameObject ground;

    public float edgeDistance = 1f;

    private Bounds levelBounds;
    private float rightLimit;
    private float leftLimit;

    // Use this for initialization
    void Start()
    {
        levelBounds = ground.GetComponent<Renderer>().bounds;
        leftLimit = (levelBounds.min.x + edgeDistance);
        rightLimit = (levelBounds.max.x - edgeDistance);
    }
	
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnInterval)
        {
            Spawn();
            timeSinceLastSpawn -= spawnInterval;
        }
    }

    private void Spawn()
    {
        float spawnX = Random.Range(leftLimit, rightLimit);
        float spawnZ = levelBounds.max.z - 10f;
        Vector3 spawnPosition = new Vector3(spawnX, 0.5f, spawnZ);

        GameObject newObject = (GameObject)Object.Instantiate(spawnable, spawnPosition, spawnable.transform.localRotation);
        if (newObject.GetComponent<DestroyWhenOutOfBounds>() != null)
        {
            newObject.GetComponent<DestroyWhenOutOfBounds>().ground = ground;
        }
    }
}
