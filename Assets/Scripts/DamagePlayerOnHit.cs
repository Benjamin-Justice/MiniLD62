using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DamagePlayerOnHit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.reduceHealth();
        }
    }
}
