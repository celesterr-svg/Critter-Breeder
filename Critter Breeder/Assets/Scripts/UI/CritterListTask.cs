using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CritterListTask : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] GameObject[] critters;
    public GameObject taskManager;

    private void Start()
    {
        getCritters();
        selectCritterTask();
    }

    public void getCritters()
    {
        critters = Array.Empty<GameObject>();
        critters = GameObject.FindGameObjectsWithTag("Critter");


        foreach (GameObject critter in critters)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(critter.name, null));
        }

        dropdown.RefreshShownValue();
    }
    
    public void selectCritterTask()
    {
        taskManager.GetComponent<TaskCompletion>().critter = critters[dropdown.value];
    }
}
