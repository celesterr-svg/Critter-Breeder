using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;
    public int foodAmount;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
