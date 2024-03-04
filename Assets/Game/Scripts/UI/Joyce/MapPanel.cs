using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MapPanel : MonoBehaviour
{
    [SerializeField] RectTransform mapRightPageRect;
    [SerializeField] RectTransform mapHolderRect;
    [SerializeField] RectTransform profileHolderRect;
    public float rotationDuration = 1.0f;
    public float rotationDuration2 = 0.1f;

    public Vector2 profileTargetPosition;
    Vector2 profileOriginalPosition;

    public Vector3 mapRightPageRotation = new Vector3(0, -180, 0);
    public Vector3 mapHolderRotation = new Vector3(0, 0, -5);

    bool isOpened = false;

    private void Start()
    {
        profileOriginalPosition = profileHolderRect.anchoredPosition;

    }
    void OnEnable()
    {
        StartCoroutine(FoldMap());
    }

    public void ToggleMapPanel()
    {
        StartCoroutine(FoldMap());
    }

    public IEnumerator FoldMap()
    {
        Quaternion startRotation = mapRightPageRect.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(mapRightPageRotation);

        Quaternion startRotation2 = mapHolderRect.rotation;
        mapHolderRotation.z *= -1;
        Quaternion targetRotation2 = startRotation2 * Quaternion.Euler(mapHolderRotation);

        if (!isOpened)
        {
            yield return new WaitForSeconds(0.4f);
        }

        float elapsedTime = 0.0f;

        while (elapsedTime < rotationDuration)
        {
            mapRightPageRect.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        mapRightPageRect.rotation = targetRotation;

        elapsedTime = 0.0f;
        while (elapsedTime < rotationDuration)
        {
            mapHolderRect.rotation = Quaternion.Slerp(startRotation2, targetRotation2, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mapHolderRect.rotation = targetRotation2;

        isOpened = !isOpened;

    }

    public void MoveProfileToTargetPosition()
    {
        profileHolderRect.DOAnchorPos(profileTargetPosition, 0.2f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }

    public void MoveProfileToOriginalPosition()
    {
        profileHolderRect.DOAnchorPos(profileOriginalPosition, 0.2f).SetEase(Ease.OutQuad).SetDelay(0.2f);
    }


}
