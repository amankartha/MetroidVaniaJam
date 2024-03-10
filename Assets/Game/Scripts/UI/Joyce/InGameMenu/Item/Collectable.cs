using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable] 
public class Collectable : MonoBehaviour
{
    public int id;
    public string content;
    public Sprite sprite;
    public CollectableType type;

}



public enum CollectableType
{
    Note,
    WorkerID,
    Letter
}
