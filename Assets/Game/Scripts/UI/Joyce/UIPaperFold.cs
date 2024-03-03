using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIPaperFold : MonoBehaviour
{
    [Header("UI Objects")]
    public RectTransform back;
    public RectTransform mask;
    public RectTransform outter;

    [Header("Flip Positions")]
    public Vector3 backStartPos;
    public Vector3 backEndPos;


    Vector3 pos; //this postion
    Vector3 currentRotation; //this rotation

    bool canFold = false;
    Vector3 currentBackPos;

    Vector3 originalMaskRotation, originalBackRotation;

    //public MMFeedbackCameraShake creditFeedback;

    void Start()
    {
        //creditFeedback.Play(Vector3.zero, 3);
        pos = transform.position;
        currentRotation = transform.eulerAngles;

        backStartPos = back.anchoredPosition;

        currentBackPos = backStartPos;

        originalBackRotation = back.eulerAngles;
        originalMaskRotation = mask.eulerAngles;
    }

    IEnumerator FoldToBack(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            currentBackPos = Vector3.Lerp(backStartPos, backEndPos, t);
            back.anchoredPosition = currentBackPos;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentBackPos = backEndPos;
        back.anchoredPosition = currentBackPos;
        canFold = false;
    }

    IEnumerator FoldToFront(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            currentBackPos = Vector3.Lerp(backEndPos, backStartPos, t);
            back.anchoredPosition = currentBackPos;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentBackPos = backStartPos;
        back.anchoredPosition = currentBackPos;
        back.eulerAngles = originalBackRotation;
        mask.eulerAngles = originalMaskRotation;
        
        canFold = false;
        transform.position = pos;
        transform.eulerAngles = currentRotation;
    }

    void LateUpdate()
    {
        if (canFold)
        {
            Fold();
        }
    }

    //Fold to the back side
    public void StartFolding()
    {
        canFold = true;
        StartCoroutine(FoldToBack(0.4f));
    }

    //Fold to the front side
    public void FoldingBack()
    {
        canFold = true;
        StartCoroutine(FoldToFront(0.4f));
    }

    void Fold()
    {
        transform.position = pos;
        transform.eulerAngles = currentRotation;

        Vector3 backPos = back.localPosition;
        float theta = Mathf.Atan2(backPos.y, backPos.x) * 180f / Mathf.PI;

        if (theta <= 0f || theta >= 90f)
        {
            return;
        }

        float degree = (-(90f - theta) * 2f) + 5f;
        back.eulerAngles = new Vector3(0f, 0f, degree);

        mask.position = (transform.position + back.position) * 0.5f;
        mask.eulerAngles = new Vector3(0f, 0f, degree * 0.5f);

        outter.position = mask.position;
        outter.eulerAngles = new Vector3(0f, 0f, degree * 0.5f + 90f);

        transform.position = pos;
        transform.eulerAngles = currentRotation;
    }
}
