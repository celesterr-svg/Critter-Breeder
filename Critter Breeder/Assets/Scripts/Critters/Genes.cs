using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genes : MonoBehaviour
{
    public enum bodyType { Circle, Square, Triangle };

    [Header("Genes")]
    [Space]
    public Color color_1;
    public Color color_2;

    [Space]
    public bodyType body_1;
    public bodyType body_2;

    [Space]
    [Range(0.1f, 0.5f)]
    public float size_1;
    [Range(0.1f, 0.5f)]
    public float size_2;

    [Space]
    public int foodLoss_1;
    public int foodLoss_2;

    [Space]
    public int health_1;
    public int health_2;

    [Space]
    public int energy_1;
    public int energy_2;

    [Space]
    public int breedingCooldown_1;
    public int breedingCooldown_2;

    [Space]
    public float strength_1;
    public float strength_2;

    [Space]
    public float intelligence_1;
    public float intelligence_2;

    [Space]
    public int potential_1;
    public int potential_2;

}
