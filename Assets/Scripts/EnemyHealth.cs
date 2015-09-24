using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public ScoreManager scoreManager;
    private int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {
            if (scoreManager != null)
            {
                scoreManager.Score += 1;
            }
            Object.Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBullet>() != null)
        {
            var playerBullet = other.GetComponent<PlayerBullet>();
            currentHealth -= playerBullet.damage;
            playerBullet.OnHit();
        }
    }
}
