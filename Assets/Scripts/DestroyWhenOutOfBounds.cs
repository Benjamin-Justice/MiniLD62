using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfBounds : MonoBehaviour
{
    public GameObject ground;
    private float minZ;
    private float maxZ;

    // Use this for initialization
    void Start()
    {
        Bounds bounds = ground.GetComponent<Renderer>().bounds;
        minZ = bounds.min.z;
        maxZ = bounds.max.z;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.z < minZ || this.transform.localPosition.z > maxZ)
        {
            Object.Destroy(this.gameObject);
        }	
    }
}
