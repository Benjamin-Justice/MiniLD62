using UnityEngine;
using System.Collections;

public class UpdatePlayerSpeed : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        PlayerSpeed.UpdateSpeed(Time.deltaTime);
    }
}
