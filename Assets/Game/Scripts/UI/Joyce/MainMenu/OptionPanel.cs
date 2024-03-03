using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private Button _filpBackButton;
    [SerializeField] private Slider _volumeSlider;
    bool shouldMove = false;

    //temp var, to be substitute with current volume value
    float tempVal = 0.8f;

    public void ResetSliderToZero()
    {
        StopAllCoroutines();
        _volumeSlider.value = 0;
    }
    public void MoveSlider()
    {
        StartCoroutine(Move(0.5f));
    }

    IEnumerator Move(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            float progress = timer / duration;

            _volumeSlider.value = Mathf.Lerp(0, tempVal, progress);
            timer += Time.deltaTime;

            yield return null;
        }

        _volumeSlider.value = tempVal;
        _filpBackButton.interactable = true;

    }
}
