using UnityEngine;
using System.Collections;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class MoveWithInput : MonoBehaviour
{
    public float moveSpeed = 20f;
    public GameObject ground;
    public GameObject graphicsNode;
    public float edgeDistance = 1.7f;

    public float maxRotation = 65f;
    public float rotationSpeed = 5f;
    public float rotationRelaxSpeed = 5f;

    private float minRotation = 10f;

    [HideInInspector]
    public bool isInTurbo;

    private float rightLimit;
    private float leftLimit;
    private Bounds levelBounds;

    // Use this for initialization
    void Start()
    {
        levelBounds = ground.GetComponent<Renderer>().bounds;
        leftLimit = (levelBounds.min.x + edgeDistance);
        rightLimit = (levelBounds.max.x - edgeDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float stepSize = Time.deltaTime * moveSpeed;
        var rightMoveVector = new Vector3(stepSize, 0f, 0f);
        float accelerationValue = 0f;
        if (Application.isMobilePlatform)
        {
            if (Input.acceleration.x > 0.05f)
            {
                accelerationValue = Input.acceleration.x * 1.5f;
                if (accelerationValue > 0.5f || accelerationValue > 0.3f && isInTurbo)
                {
                    accelerationValue = 1f;
                }
                Move(rightMoveVector, accelerationValue);
            }
            else if (Input.acceleration.x < -0.05f)
            {
                accelerationValue = Input.acceleration.x * 1.5f;
                if (accelerationValue < -0.5f || accelerationValue < 0.3f && isInTurbo)
                {
                    accelerationValue = -1f;
                }
                Move(rightMoveVector, accelerationValue);
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0f)
            {
                accelerationValue = Input.GetAxis("Horizontal");
                if (accelerationValue > 0.5f)
                {
                    accelerationValue = 1f;
                }
                Move(rightMoveVector, accelerationValue);
            }
            else if (Input.GetAxis("Horizontal") < -0f)
            {
                accelerationValue = Input.GetAxis("Horizontal");
                if (accelerationValue < -0.5f)
                {
                    accelerationValue = -1f;
                }
                Move(rightMoveVector, accelerationValue);
            }
        }
        RotateGraphics(accelerationValue);
        isInTurbo = Math.Abs(accelerationValue) > 0.9f ? true : false;
    }

    //TODO Calculate rotation Euler and apply it once at the end
    void RotateGraphics(float accelerationValue)
    {
        var currentZRotation = graphicsNode.transform.localRotation.eulerAngles.z;
        if (Math.Abs(accelerationValue) > 0.01f)
        {
            float frameRotation = accelerationValue * -rotationSpeed;
            if (IsWithinZRotationBounds(currentZRotation + frameRotation, accelerationValue))
            {
                graphicsNode.transform.Rotate(0f, 0f, frameRotation);
            }
            else
            {
                float newRotation = frameRotation > 0f ? maxRotation * -accelerationValue : 360 - (maxRotation * accelerationValue);
                graphicsNode.transform.localRotation = Quaternion.AngleAxis(newRotation, Vector3.forward);
            }
        }
        else if (0.01f < currentZRotation && currentZRotation < 360 - 0.01f)
        {
            float frameRotation = 0f;
            // rotated left
            if (currentZRotation <= maxRotation + 1)
            {
                frameRotation = -Time.deltaTime * moveSpeed * rotationRelaxSpeed;
            }
            // rotated right
            else if (currentZRotation >= 360 - maxRotation - 1)
            {
                frameRotation = Time.deltaTime * moveSpeed * rotationRelaxSpeed;
            }
            graphicsNode.transform.Rotate(0f, 0f, frameRotation);

            SanitizeRotation(currentZRotation);
        }
    }

    void SanitizeRotation(float currentZRotation)
    {
        if ((currentZRotation <= minRotation) || (currentZRotation >= 360 - minRotation))
        {
            graphicsNode.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.zero);
        }
    }

    //TODO why did I need the accel here again?
    bool IsWithinZRotationBounds(float zRotation, float acceleration)
    {
        bool result = zRotation > 360 - maxRotation * acceleration || zRotation < maxRotation * acceleration;
        return result;
    }

    bool IsWithinXAxisBounds(Vector3 position)
    {
        return position.x > leftLimit &&
        position.x < rightLimit;
    }

    void Move(Vector3 moveVector, float acceleration)
    {
        moveVector *= acceleration;
        if (IsWithinXAxisBounds(transform.localPosition + moveVector))
        {
            transform.Translate(moveVector);
        }
        else
        {
            float xLimit = moveVector.x > 0f ? rightLimit : leftLimit;
            transform.localPosition = new Vector3(xLimit, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
