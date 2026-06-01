using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] StrengthMinigame bar;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bar")
        {
            bar.correct = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bar")
        {
            bar.correct = false;
        }
    }
}
