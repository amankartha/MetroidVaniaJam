using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable] 
public class Collectable : MonoBehaviour
{
    public int id;
    public string content;
    public CollectableType type;

    [SerializeField] TMP_Text contentText;
    public void SetUI()
    {
        contentText.text = id.ToString();
    }
}



public enum CollectableType
{
    Note,
    WorkerID,
    Letter
}
