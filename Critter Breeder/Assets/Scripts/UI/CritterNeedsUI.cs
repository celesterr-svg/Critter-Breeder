using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CritterNeedsUI : MonoBehaviour
{
    public GameObject critter;
    private CritterNeeds needs;
    [SerializeField] Image critterimg;
    [SerializeField] Image health;
    [SerializeField] Image food;
    [SerializeField] Image energy;

    [SerializeField] TextMeshProUGUI strength;
    [SerializeField] TextMeshProUGUI intelligence;

    private void Update()
    {
        if(critter != null)
        {
            GameObject.FindGameObjectWithTag("Critter Data Canva").GetComponent<Canvas>().enabled = true;
            updateView();
        } else
        {
            GameObject.FindGameObjectWithTag("Critter Data Canva").GetComponent<Canvas>().enabled = false;
        }
    }
    private void updateView()
    {
        needs = critter.GetComponent<CritterNeeds>();

        critterimg.sprite = critter.GetComponent<SpriteRenderer>().sprite;

        health.fillAmount = (needs.currentHealth * 1.0f / needs.maxHealth);
        food.fillAmount = (needs.currentFood * 1.0f / needs.maxFood);
        energy.fillAmount = (needs.currentEnergy * 1.0f / needs.maxEnergy);

        strength.text = critter.GetComponent<ManageStats>().getGenes("Strength").ToString();
        intelligence.text = critter.GetComponent<ManageStats>().getGenes("Intelligence").ToString();
    }

    public void exit()
    {
        critter = null;
    }
}
