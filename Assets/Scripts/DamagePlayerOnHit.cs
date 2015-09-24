using UnityEngine;
using System.Collections;

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
        if (other.gameObject.GetComponent<PlayerHealth>() != null)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
