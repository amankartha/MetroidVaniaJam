using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class GivePlayerAbility : MonoBehaviour
{

    public bool GiveAbilityOne = false;
    public bool GiveAbilityTwo = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == GameManager.Instance.goMainPlayer)
        {
            if (GiveAbilityOne)
            {
                GameManager.Instance.PlayerScript.GetAbilityOne();
            }

            if (GiveAbilityTwo)
            {
                GameManager.Instance.PlayerScript.GetAbilityTwo();
            }
            Destroy(this.gameObject);
        }
    }
}
