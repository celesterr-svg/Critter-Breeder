using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageStats : MonoBehaviour
{
    private Genes genes;

    public float strength;
    public float intelligence;
    public float potential;

    private void Start()
    {
        genes = GetComponent<Genes>();

        strength = (genes.strength_1 + genes.strength_2) / 2;
        intelligence = (genes.intelligence_1 + genes.intelligence_2) / 2;
        potential = (genes.potential_1 + genes.potential_2) / 2;
    }

    public void trainStrength(float amount)
    {
        if(amount > potential)
        {
            return;
        } else
        {
            potential -= amount;
            strength += amount;
        }
    }

    public void trainIntelligence(float amount)
    {
        if (amount > potential)
        {
            return;
        }
        else
        {
            potential -= amount;
            intelligence += amount;
        }
    }

    public float getGenes(string gene)
    {
        Dictionary<string, float> geneValues = new Dictionary<string, float>
        {
            {"Strength", strength },
            {"Intelligence", intelligence }
        };

        if (geneValues.ContainsKey(gene))
        {
            return geneValues[gene];
        }

        return 0;
    }
}
