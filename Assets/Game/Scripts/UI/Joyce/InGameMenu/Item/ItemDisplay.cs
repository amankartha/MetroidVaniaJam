using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public GameObject itemPrefab;
    public RectTransform itemTrans;

    public List<Collectable> itemList = new List<Collectable>();
    List<GameObject> itemGameObjectList = new List<GameObject>();

    [SerializeField] Image displayImage;
    [SerializeField] TMP_Text contentText;
    [SerializeField] InGameMenuUI inGameMuneUI;

    public void AddCollectable(Collectable collectable)
    {
        GameObject go = Instantiate(itemPrefab, itemTrans);
        Collectable goCollectable = go.GetComponent<Collectable>();


        goCollectable.id = collectable.id;
        goCollectable.sprite = collectable.sprite;
        goCollectable.title = collectable.title;
        goCollectable.content = collectable.content;
        goCollectable.type = collectable.type;
        itemList.Add(goCollectable);
        itemGameObjectList.Add(go);
        SortList();

        go.GetComponent<ItemButton>().SetUIDisplay(displayImage, contentText);
        inGameMuneUI.OpenInGameMenuWithItemTab();
        go.GetComponent<Button>().onClick.Invoke();
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
        for(int i = 0; i < itemGameObjectList.Count; i++)
        {
            Collectable collectable = itemGameObjectList[i].GetComponent<Collectable>();
            collectable.id = itemList[i].id;
            collectable.sprite = itemList[i].sprite;
            collectable.title = itemList[i].title;
            collectable.content = itemList[i].content;
            collectable.type = itemList[i].type;
        }

        

        /*//clear ui
        foreach (Transform child in itemTrans.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Collectable collectable in itemList)
        {
            InstantiateUIElement(collectable);
        }*/
    }

    void InstantiateUIElement(Collectable collectable)
    {
        GameObject go = Instantiate(itemPrefab, itemTrans);
        Collectable goCollectable = go.GetComponent<Collectable>();

        goCollectable.id = collectable.id;
        goCollectable.content = collectable.content;
        goCollectable.type = collectable.type;
    }
}
