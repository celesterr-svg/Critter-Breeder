using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Breeding : MonoBehaviour
{
    public GameObject parent_1;
    public GameObject parent_2;

    public GameObject child;

    [Space]
    [Range(0f, 1f)]
    public float geneticVariation;

    public void spawnChild()
    {
        if (parent_1 == null && parent_2 == null)
        {
            return;
        }

        if(parent_1 == parent_2)
        {
            return;
        }

        GameObject baby = Instantiate(child, transform.position, Quaternion.identity);
        setGenes(baby);

        parent_1.GetComponent<CritterNeeds>().resetbreedCooldown();
        parent_2.GetComponent<CritterNeeds>().resetbreedCooldown();
    }

    public void setGenes(GameObject child)
    {
        Genes childGenes = child.GetComponent<Genes>();
        Genes p1Genes = parent_1.GetComponent<Genes>();
        Genes p2Genes = parent_2.GetComponent<Genes>();

        //parent 1
        float p1_str1 = p1Genes.strength_1;
        float p1_str2 = p1Genes.strength_2;

        float p1_int1 = p1Genes.intelligence_1;
        float p1_int2 = p1Genes.intelligence_2;

        //parent 2
        float p2_str1 = p2Genes.strength_1;
        float p2_str2 = p2Genes.strength_2;

        float p2_int1 = p2Genes.intelligence_1;
        float p2_int2 = p2Genes.intelligence_2;

        
        //color        
        if (Random.value < 0.5f)
        {
            //parent 1 is chosen for first gene
            if (Random.value < 0.5f)
            {
                childGenes.color_1 = p1Genes.color_1;
            } else
            {
                childGenes.color_1 = p1Genes.color_2;
            }

            //parent 2 is chosen for second gene
            if (Random.value < 0.5f)
            {
                childGenes.color_2 = p2Genes.color_1;
            }
            else
            {
                childGenes.color_2 = p2Genes.color_2;
            }
        } else
        {
            //parent 2 is chosen for first gene
            if (Random.value < 0.5f)
            {
                childGenes.color_1 = p2Genes.color_1;
            }
            else
            {
                childGenes.color_1 = p2Genes.color_2;
            }

            //parent 1 is chosen for second gene
            if (Random.value < 0.5f)
            {
                childGenes.color_2 = p1Genes.color_1;
            }
            else
            {
                childGenes.color_2 = p1Genes.color_2;
            }
        }

        //body
        if (Random.value < 0.5f)
        {
            //parent 1 is chosen for first gene
            if (Random.value < 0.5f)
            {
                childGenes.body_1 = p1Genes.body_1;
            }
            else
            {
                childGenes.body_1 = p1Genes.body_2;
            }

            //parent 2 is chosen for second gene
            if (Random.value < 0.5f)
            {
                childGenes.body_2 = p2Genes.body_1;
            }
            else
            {
                childGenes.body_2 = p2Genes.body_2;
            }
        }
        else
        {
            //parent 2 is chosen for first gene
            if (Random.value < 0.5f)
            {
                childGenes.body_1 = p2Genes.body_1;
            }
            else
            {
                childGenes.body_1 = p2Genes.body_2;
            }

            //parent 1 is chosen for second gene
            if (Random.value < 0.5f)
            {
                childGenes.body_2 = p1Genes.body_1;
            }
            else
            {
                childGenes.body_2 = p1Genes.body_2;
            }
        }


        //for numeric values inheritance is closer to the average between the parents.
        //size
        //gene 1
        childGenes.size_1 = (p1Genes.size_1 + p2Genes.size_1) / 2; 
        //add genetic variaton
        if (Random.value < 0.5f)
        {
            childGenes.size_1 += Random.Range(0f, geneticVariation);
        } else
        {
            childGenes.size_1 -= Random.Range(0f, geneticVariation);
        }
        childGenes.size_1 = Mathf.Round(childGenes.size_1 * 100f) / 100f;

        //gene 2
        childGenes.size_2 = (p1Genes.size_2 + p2Genes.size_2) / 2;
        //add genetic variaton
        if (Random.value < 0.5f)
        {
            childGenes.size_2 += Random.Range(0f, geneticVariation);
        }
        else
        {
            childGenes.size_2 -= Random.Range(0f, geneticVariation);
        }
        childGenes.size_2 = Mathf.Round(childGenes.size_2 * 100f) / 100f;

        //strength
        //gene 1
        childGenes.strength_1 = (p1_str1 + p2_str1) / 2;
        //add genetic variaton
        //teorema del limite central, al sumar varios numeros aleatorios y obtener su promedio su distribucion se aproxima a una campana de gauss
        childGenes.strength_1 = childGenes.strength_1 + childGenes.strength_1 * (  ( Random.Range(0f, 1f) + Random.Range(0f, 1f) + Random.Range (0f, 1f) ) / 3 - 0.5f );
        childGenes.strength_1 = Mathf.Round(childGenes.strength_1 * 100f) / 100f;
        //que el valor resultante no sea menor al minimo gen entre los dos padres
        if (p1_str1 < p2_str1)
        {
            childGenes.strength_1 = Mathf.Clamp(childGenes.strength_1, p1_str1, (p2_str1 + p2_str1 * 0.25f));
        }
        else 
        {
            childGenes.strength_1 = Mathf.Clamp(childGenes.strength_1, p2_str1, (p1_str1 + p1_str1 * 0.25f));
        }

        //gene 2
        childGenes.strength_2 = (p1_str2 + p2_str2) / 2;

        childGenes.strength_2 = childGenes.strength_2 + childGenes.strength_2 * ((Random.Range(0f, 1f) + Random.Range(0f, 1f) + Random.Range(0f, 1f)) / 3 - 0.5f);
        childGenes.strength_2 = Mathf.Round(childGenes.strength_2 * 100f) / 100f;

        if (p1_str2 < p2_str2)
        {
            childGenes.strength_2 = Mathf.Clamp(childGenes.strength_2, p1_str2, (p2_str2 + p2_str2 * 0.25f));
        }
        else
        {
            childGenes.strength_2 = Mathf.Clamp(childGenes.strength_2, p2_str2, (p1_str2 + p1_str2 * 0.25f));
        }

        //intelligence
        //gene 1
        childGenes.intelligence_1 = (p1_int1 + p2_int1) / 2;

        childGenes.intelligence_1 = childGenes.intelligence_1 + childGenes.intelligence_1 * ((Random.Range(0f, 1f) + Random.Range(0f, 1f) + Random.Range(0f, 1f)) / 3 - 0.5f);
        childGenes.intelligence_1 = Mathf.Round(childGenes.intelligence_1 * 100f) / 100f;

        if (p1_int1 < p2_int1)
        {
            childGenes.intelligence_1 = Mathf.Clamp(childGenes.intelligence_1, p1_int1, (p2_int1 + p2_int1 * 0.25f));
        }
        else
        {
            childGenes.intelligence_1 = Mathf.Clamp(childGenes.intelligence_1, p2_int1, (p1_int1 + p1_int1 * 0.25f));
        }

        //gene 2
        childGenes.intelligence_2 = (p1_int2 + p2_int2) / 2;

        childGenes.intelligence_2 = childGenes.intelligence_2 + childGenes.intelligence_2 * ((Random.Range(0f, 1f) + Random.Range(0f, 1f) + Random.Range(0f, 1f)) / 3 - 0.5f);
        childGenes.intelligence_2 = Mathf.Round(childGenes.intelligence_2 * 100f) / 100f;

        if (p1_int2 < p2_int2)
        {
            childGenes.intelligence_2 = Mathf.Clamp(childGenes.intelligence_2, p1_int2, (p2_int2 + p2_int2 * 0.25f));
        }
        else
        {
            childGenes.intelligence_2 = Mathf.Clamp(childGenes.intelligence_2, p2_int2, (p1_int2 + p1_int2 * 0.25f));
        }
    }
}
