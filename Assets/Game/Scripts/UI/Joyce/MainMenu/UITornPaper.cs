using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITornPaper : MonoBehaviour
{
    [Header("UI Objects")]
    public RectTransform maskLeft;
    public RectTransform maskRight;

    [Header("Rotation Values")]
    public Vector3 leftRotationDestination;
    public Vector3 rightRotationDestination;

    Vector3 leftRotation, rightRotation;
    Quaternion initialLeftRotation, initialRightRotation;
    Quaternion startLeftRotation, startRightRotation;

    float transitionTimer = 0.0f;
    bool isTransitioning = false;
    float transitionDuration = 0.3f;


    void Start()
    {
        initialLeftRotation = maskLeft.rotation;
        initialRightRotation = maskRight.rotation;
        startLeftRotation = initialLeftRotation;
        startRightRotation = initialRightRotation;
        leftRotation = leftRotationDestination;
        rightRotation = rightRotationDestination;
    }

    void Update()
    {
        if (isTransitioning)
        {
            Torn();
        }
    }

    public void TornPaper(float duration, bool repair)
    {
        transitionDuration = duration;
        transitionTimer = 0.0f;
        isTransitioning = true;

        if (repair)
        {
            startLeftRotation = Quaternion.Euler(leftRotation);
            startRightRotation = Quaternion.Euler(rightRotation);
            leftRotation = initialLeftRotation.eulerAngles;
            rightRotation = initialRightRotation.eulerAngles;
        }
        else
        {
            leftRotation = leftRotationDestination;
            rightRotation = rightRotationDestination;
            startLeftRotation = initialLeftRotation;
            startRightRotation = initialRightRotation;
        }
    }

    void Torn()
    {
        transitionTimer += Time.deltaTime;

        float t = Mathf.Clamp01(transitionTimer / transitionDuration);

        maskLeft.rotation = Quaternion.Lerp(startLeftRotation, Quaternion.Euler(leftRotation), t);
        maskRight.rotation = Quaternion.Lerp(startRightRotation, Quaternion.Euler(rightRotation), t);

        if (transitionTimer >= transitionDuration)
        {
            maskLeft.eulerAngles = leftRotation;
            maskRight.eulerAngles = rightRotation;
            isTransitioning = false;
        }
    }
}
