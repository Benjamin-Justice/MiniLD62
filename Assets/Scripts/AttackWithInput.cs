using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveWithInput))]
public class AttackWithInput : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        if (attackActive())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayerWeapon[] weapons = GetComponentsInChildren<PlayerWeapon>();
        foreach (PlayerWeapon weapon in weapons)
        {
            weapon.Shoot();
        }
    }



    static bool attackActive()
    {
        bool isShooting = false;
        if (Application.isMobilePlatform)
        {
            foreach (Touch touch in Input.touches)
            {
                isShooting = touch.phase == TouchPhase.Stationary || isShooting;
                isShooting = touch.phase == TouchPhase.Moved || isShooting;
                isShooting = touch.phase == TouchPhase.Began || isShooting;
            }
        }
        else
        {
            isShooting = Input.GetButton("Fire1");
        }
        return isShooting;
    }
}
