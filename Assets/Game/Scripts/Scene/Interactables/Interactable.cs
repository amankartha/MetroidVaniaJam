using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected BoxCollider2D _boxCollider2D; 
    protected virtual void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        
    }
}
