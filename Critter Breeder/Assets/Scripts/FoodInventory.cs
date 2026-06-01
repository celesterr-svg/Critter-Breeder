using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInventory : MonoBehaviour
{
    public List<GameObject> items = new();
    public GameObject invSlotPrefab;
    public GameObject critter;
    private CritterNeeds critterNeeds;

    private void Start()
    {       
        critterNeeds = critter.GetComponent<CritterNeeds>();        
    }

    private void OnEnable()
    {
        RefreshList();        
    }

    private void DrawItems()    
    {    
        foreach (GameObject food in items)
        {
            var slot = Instantiate(invSlotPrefab, gameObject.transform);
            var button = slot.GetComponent<Button>();

            button.onClick.AddListener(() => critterNeeds.eat(food.GetComponent<Food>().foodAmount));
            button.onClick.AddListener(food.GetComponent<Food>().Destroy);
            button.onClick.AddListener(() => Invoke(nameof(RefreshList), 0.1f));
        }
    }

    private void EraseChildren()
    {
        if(transform.childCount == 0)
        {
            return;
        }

        for(int i = transform.childCount -1; i >= 0; i--)
        {
           Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void RefreshList()
    {
        EraseChildren();        

        items.Clear();
        items.AddRange(GameObject.FindGameObjectsWithTag("Item"));
        DrawItems();
    }
}
