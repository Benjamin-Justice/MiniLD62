using UnityEngine;
using System.Collections;

public class AttackWithInput : MonoBehaviour
{
    public GameObject bullet;
    public float interval = 0.5f;

    float timePassed = 0.0f;

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        if (canShoot() && attackActive())
        {
            Object.Instantiate(bullet, transform.localPosition, transform.localRotation);
            timePassed = 0.0f;
        }
        timePassed += Time.deltaTime;
    }

    bool canShoot()
    {
        var value = timePassed > interval;
        if (GetComponent<MoveWithInput>() != null)
        {
            value = !GetComponent<MoveWithInput>().isInTurbo && value;
        }
        return value;
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
