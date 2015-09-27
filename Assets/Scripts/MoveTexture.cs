using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MoveTexture : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }
	
    // Update is called once per frame
    void Update()
    {
        var material = GetComponent<Renderer>().material;
        var offsetDelta = -Time.deltaTime * PlayerSpeed.currentSpeed / 10f;
        var oldOffset = material.GetTextureOffset("_MainTex");

        material.mainTextureOffset = new Vector2(0, oldOffset.y + offsetDelta);
        material.SetTextureOffset("_BumpMap", new Vector2(0, oldOffset.y + offsetDelta));
    }
}