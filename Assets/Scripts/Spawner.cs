using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    public float interval = 0.500f;
    private float timePassed = 0.0f;

    public GameObject leftWall;
    public GameObject rightWall;
    public float edgeDistance = 1.0f;

    private float rightLimit;
    private float leftLimit;

    // Use this for initialization
    void Start()
    {
        leftLimit = (leftWall.transform.localPosition.x + edgeDistance);
        rightLimit = (rightWall.transform.localPosition.x - edgeDistance);
    }
	
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > interval)
        {
            Spawn();
            timePassed -= interval;
        }
    }

    private void Spawn()
    {
        float spawnX = Random.Range(leftLimit, rightLimit);
        Vector3 spawnPosition = new Vector3(spawnX, 0.5f, 60.0f);
        GameObject newObject = (GameObject)Object.Instantiate(spawnable, spawnPosition, spawnable.transform.localRotation);
        if (GetComponent<ScoreManager>() != null && newObject.GetComponent<EnemyHealth>())
        {
            newObject.GetComponent<EnemyHealth>().scoreManager = GetComponent<ScoreManager>();
        }
    }
}
