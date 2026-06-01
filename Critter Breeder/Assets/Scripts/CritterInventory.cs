using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CritterInventory : MonoBehaviour
{

    public List<GameObject> critters = new List<GameObject>();
    public GameObject imagePrefab;

    private void Start()
    {
        critters.AddRange(GameObject.FindGameObjectsWithTag("Critter"));

        foreach (GameObject critter in critters)
        {
            var image = Instantiate(imagePrefab, gameObject.transform);
            image.GetComponent<Image>().sprite = critter.GetComponent<SpriteRenderer>().sprite;
            image.GetComponent<SelectCritter>().critter = critter;
        }
    } 
        
}
