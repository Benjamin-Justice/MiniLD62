using UnityEngine;
using System.Collections;

public class MoveTexture : MonoBehaviour
{
    public float speed = 1.0f;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -Time.time * speed);
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(0, -Time.time * speed));
    }
}
