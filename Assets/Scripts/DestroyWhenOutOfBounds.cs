using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfBounds : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.z < -4.5f || this.transform.localPosition.z > 66.0f)
        {
            Object.Destroy(this.gameObject);
        }	
    }
}
