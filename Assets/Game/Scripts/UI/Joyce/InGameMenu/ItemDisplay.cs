using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemPrefab;
    public RectTransform itemTrans;

    public List<Collectable> itemList = new List<Collectable>();


    public void AddCollectable(Collectable collectable)
    {
        GameObject go = Instantiate(itemPrefab, itemTrans);
        Collectable goCollectable = go.GetComponent<Collectable>();
        goCollectable.SetUI();
        goCollectable.id = collectable.id;
        goCollectable.content = collectable.content;
        goCollectable.type = collectable.type;
        goCollectable.SetUI();
        itemList.Add(collectable);
        SortList();
    }

    void SortList()
    {
        itemList = itemList.OrderBy(collectable => collectable.type)
            .ThenBy(collectable => collectable.id)
            .ToList();

        RefreshUI();
    }

    void RefreshUI()
    {
        //clear ui
        foreach (Transform child in itemTrans.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Collectable collectable in itemList)
        {
            InstantiateUIElement(collectable);
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
