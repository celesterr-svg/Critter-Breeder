using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CritterList : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] GameObject[] critters;
    public GameObject breeder;
    public bool parent1;

    private void Start()
    {
        getCritters();
        setParent();
    }

    public void getCritters()
    {
        critters = GameObject.FindGameObjectsWithTag("Critter");


        foreach (GameObject critter in critters)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(critter.name, null));
        }

        dropdown.RefreshShownValue();
    }
    public void setParent()
    {
        var breeding = breeder.GetComponent<Breeding>();

        if (parent1)
        {
            breeding.parent_1 = critters[dropdown.value];
        } else
        {
            breeding.parent_2 = critters[dropdown.value];
        }
    }
}
