using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CritterNeeds : MonoBehaviour
{
    [SerializeField] private GameObject sender;
    [SerializeField] private Genes genes;

    //hunger settings
    public int maxFood = 100;
    public int currentFood;
    public int foodLoss;

    //health settings
    public int maxHealth;
    public int currentHealth;

    //energy settings
    public int maxEnergy;
    public int currentEnergy;
    private bool exhausted;

    //breeding cooldown settings
    private int cooldownAmount;
    public int currentCooldown;

    private void Start()
    {
        sender = GameObject.FindGameObjectWithTag("Day Progression");
        genes = gameObject.GetComponent<Genes>();
        
        if (sender != null) 
        {
            DayProgression dayProgression = sender.GetComponent<DayProgression>();
            dayProgression.OnDayAdvanced.AddListener(newDay);
        }

        //asignar valores segun genetica
        foodLoss = (genes.foodLoss_1 + genes.foodLoss_2) / 2;

        maxHealth = (genes.health_1 + genes.health_2) / 2;

        maxEnergy = (genes.energy_1 + genes.energy_2) / 2;

        cooldownAmount = (genes.breedingCooldown_1 + genes.breedingCooldown_2) / 2;

        //asignar valores actuales
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        currentFood = maxFood;
    }

    //funciones llamadas cuando empieza un nuevo dia
    public void newDay()
    {
        loseHealth();
        heal(maxHealth / 10);
        rest();
        hungry();
        breedCooldown(1);        
    }

    //food
    private void hungry()
    {
        currentFood -= foodLoss;
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
    }

    public void eat(int amount)
    {
        currentFood = currentFood + amount;
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
    }

    //health
    private void loseHealth()
    {
        if(currentFood == 0)
        {
            currentHealth -= 15;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }

    public void heal(int healAmount)
    {
        if (currentFood > 0 && currentEnergy > 0) 
        {
            currentHealth = currentHealth + healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }

    //energy
    private void rest()
    {
        if(currentEnergy == 0)
        {
            exhausted = true;
        } else if (currentEnergy == maxEnergy)
        {
            exhausted = false;
        }

        if (exhausted)
        {
            currentEnergy += maxEnergy / 3;
        } else
        {
            currentEnergy = maxEnergy;
        }

        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    public void recoverEnergy(int energyAmount)
    {
        currentEnergy += energyAmount;
    }

    public void loseEnergy(int energyAmount)
    {
        currentEnergy -= energyAmount;
    }

    //breeding
    public void breedCooldown(int days)
    {
        currentCooldown -= days;
        currentCooldown = Mathf.Clamp(currentCooldown, 0, cooldownAmount);
    }
    public void resetbreedCooldown()
    {
        currentCooldown = cooldownAmount;
    }
}
