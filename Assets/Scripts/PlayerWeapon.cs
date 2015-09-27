using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public float interval = 0.5f;
    private float timePassed = 0f;

    public GameObject bullet;
    public Transform[] bulletSpawnPositions;

    void Start()
    {
        
    }

    void Update()
    {
        timePassed += Time.deltaTime;
    }

    public void Shoot()
    {
        if (canShoot())
        {
            foreach (Transform spawnTransform in bulletSpawnPositions)
            {
                Vector3 spawnPosition = new Vector3(spawnTransform.position.x, 1f, spawnTransform.position.z);
                GameObject bulletInstance = (GameObject)UnityEngine.Object.Instantiate(bullet, spawnPosition, spawnTransform.localRotation);
                try
                {
                    bulletInstance.GetComponent<DestroyWhenOutOfBounds>().ground = GetComponentInParent<MoveWithInput>().ground;
                } catch (NullReferenceException)
                {
                    Debug.LogError("Missing DestroyWhenOutOfBounds Component on Bullet! Pausing Simulation.");
                    Debug.Break();
                }
            }
            timePassed = 0.0f;
        }
    }

    bool canShoot()
    {
        var value = timePassed > interval;
        if (GetComponentInParent<MoveWithInput>() != null)
        {
            value = !GetComponentInParent<MoveWithInput>().isInTurbo && value;
        }
        return value;
    }
}
