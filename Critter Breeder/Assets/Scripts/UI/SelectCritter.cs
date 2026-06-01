using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCritter : MonoBehaviour
{
    public GameObject critter;
    public GameObject critterView;

    private void Start()
    {
        critterView = GameObject.FindGameObjectWithTag("Critter Data");
    }

    public void select()
    {
        critterView.GetComponent<CritterNeedsUI>().critter = critter;        
        GameObject.FindGameObjectWithTag("Critter Inventory").GetComponent<Canvas>().enabled = false;
    }
}
