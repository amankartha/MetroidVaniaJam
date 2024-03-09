using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;


public class ItemDisplay : MonoBehaviour
{
    public GameObject itemPrefab;
    public RectTransform itemTrans;

    public List<Collectable> itemList = new List<Collectable>();

    public UnityEvent<Collectable> myEvent;


    private void Start()
    {
        myEvent.AddListener(AddCollectable);
    }

    public void AddCollectable(Collectable collectable)
    {
        Debug.Log("received id: " + collectable.id);
        GameObject go = Instantiate(itemPrefab, itemTrans);
        Collectable goCollectable = go.GetComponent<Collectable>();
        goCollectable.SetUI();
        goCollectable.id = collectable.id;
        goCollectable.content = collectable.content;
        goCollectable.type = collectable.type;
        goCollectable.SetUI();
        itemList.Add(collectable);
        //SortList();
    }

    void SortList()
    {
        var sortedList = itemList.OrderBy(go =>
        {
            Collectable collectable = go.GetComponent<Collectable>();
            return collectable.type;
        }).ThenBy(go =>
        {
            Collectable collectable = go.GetComponent<Collectable>();
            return collectable.id;
        }).ToList();

        RefreshUI();
    }

    void RefreshUI()
    {
        ClearUI();
        foreach (Collectable collectable in itemList)
        {
            InstantiateUIElement(collectable);
        }
    }

    void ClearUI()
    {       
        foreach (Transform child in itemTrans.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void InstantiateUIElement(Collectable collectable)
    {
        GameObject go = Instantiate(itemPrefab, itemTrans);
        Collectable goCollectable = go.GetComponent<Collectable>();

        goCollectable.id = collectable.id;
        goCollectable.content = collectable.content;
        goCollectable.type = collectable.type;
        goCollectable.SetUI();

    }
}
