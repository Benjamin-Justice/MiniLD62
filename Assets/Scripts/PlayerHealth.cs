using UnityEngine;
using System.Collections;

// TODO Don't like this relationship between the collider on gfx and the player node.
// See reduceHealth method for ugliness.
public class PlayerHealth : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    public void reduceHealth()
    {
        PlayerWeapon[] weapons = GetComponentsInChildren<PlayerWeapon>();
        if (weapons.Length > 1)
        {
            weapons [weapons.Length - 1].gameObject.SetActive(false);
            PlayerSpeed.ResetSpeed();
        }
        else
        {
            Util.QuitLevel(ScoreManager.score);
        }

    }

    public void increaseHealth()
    {
        Debug.Log("IncreaseHealth");
        PlayerWeapon[] allWeapons = GetComponentsInChildren<PlayerWeapon>(true);
        foreach (var playerWeapon in allWeapons)
        {
            if (playerWeapon.gameObject.activeSelf == false)
            {
                playerWeapon.gameObject.SetActive(true);
                break;
            }
        }
    }
}
