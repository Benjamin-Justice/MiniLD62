using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    public float minInterval = 0.5f;
    public float maxInterval = 1.5f;
    private float spawnInterval;
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
        spawnInterval = Random.Range(minInterval, maxInterval);
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
            spawnInterval = Random.Range(minInterval, maxInterval);
        }
    }
    //TODO How can I remove these stupid Ground references?
    // I don't wanna use a Singleton for the Ground which gets its instance via String reference.
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
        if (newObject.GetComponent<EnemyMovement>() != null)
        {
            newObject.GetComponent<EnemyMovement>().ground = ground;
        }

    }
}
