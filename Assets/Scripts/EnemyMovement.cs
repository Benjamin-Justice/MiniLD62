using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class EnemyMovement : MonoBehaviour
{
    public float horizontalSpeed = 10f;
    public float slowDown = 10f;
    public float speedUp = 10f;
    public GameObject ground;

    private bool goingLeft;
    private Bounds levelBounds;
    private float leftLimit;
    private float rightLimit;

    // Use this for initialization
    void Start()
    {
        goingLeft = Util.randomBool();
        Bounds colliderBounds = GetComponent<Collider>().bounds;
        levelBounds = ground.GetComponent<Renderer>().bounds;
        leftLimit = (levelBounds.min.x + colliderBounds.size.x / 2);
        rightLimit = (levelBounds.max.x - colliderBounds.size.x / 2);
    }
	
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < 20)
        {
            float horizontalStep = horizontalSpeed * Time.deltaTime;
            horizontalStep = goingLeft ? -horizontalStep : horizontalStep;
            if (goingLeft)
            {
                if (this.transform.position.x + horizontalStep < leftLimit)
                {
                    horizontalStep = 0;
                    goingLeft = !goingLeft;
                }
            }
            else
            {
                if (this.transform.position.x + horizontalStep > rightLimit)
                {
                    horizontalStep = 0;
                    goingLeft = !goingLeft;
                }
            }
            this.transform.Translate(horizontalStep, 0.0f, Time.deltaTime * slowDown);
        }
        else
        {
            this.transform.Translate(0.0f, 0.0f, Time.deltaTime * -speedUp);
        }
    }
}
