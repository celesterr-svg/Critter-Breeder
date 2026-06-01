using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject minigame;

    public void startMiniGame()
    {
        var game = Instantiate(minigame);
        EventSystem.current.SetSelectedGameObject(null);

        var strgame = game.GetComponent<StrengthMinigame>();
        var intgame = game.GetComponent<MemoryMinigame>();

        if (strgame != null)
        {
            strgame.critter = GameObject.FindGameObjectWithTag("Critter Data").GetComponent<CritterNeedsUI>().critter;
        }
        if (intgame != null) 
        {
            intgame.critter = GameObject.FindGameObjectWithTag("Critter Data").GetComponent<CritterNeedsUI>().critter;
        }
    }
}
