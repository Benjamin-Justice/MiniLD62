using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 1;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    public void OnHit()
    {
        Object.Destroy(gameObject);
    }
}
