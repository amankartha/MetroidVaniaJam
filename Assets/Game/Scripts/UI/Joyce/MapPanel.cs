using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{
    [SerializeField] RectTransform mapRightPageRect;
    [SerializeField] RectTransform mapHolderRect;
    public float rotationDuration = 1.0f;
    public float rotationDuration2 = 0.1f;

    public Vector3 mapRightPageRotation = new Vector3(0, -180, 0);
    public Vector3 mapHolderRotation = new Vector3(0, 0, -5);

    bool isOpened;

    public void ClickMapButton()
    {
        if (!isOpened)
        {
            StartCoroutine(OpenMap());
        }
    }

    public IEnumerator OpenMap()
    {
        Quaternion startRotation = mapRightPageRect.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(mapRightPageRotation);

        Quaternion startRotation2 = mapHolderRect.rotation;
        mapHolderRotation.z *= -1;
        Quaternion targetRotation2 = startRotation2 * Quaternion.Euler(mapHolderRotation);

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

    
}
