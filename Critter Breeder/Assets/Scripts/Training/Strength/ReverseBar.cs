using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseBar : MonoBehaviour
{
    [SerializeField] StrengthMinigame bar;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bar")
        {
            bar.right = !bar.right;
        }
    }
}
