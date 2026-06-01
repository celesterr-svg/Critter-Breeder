using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class StrengthMinigame : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject correctZone;
    [SerializeField] float speed = 500;
    public bool right = true;
    public bool correct = true;

    [SerializeField] int score;
    [SerializeField] float size = 1.5f;
    [SerializeField] int errors;

    public GameObject critter;

    [Header("Text")]
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textErrors;

    private void Start()
    {
        correctZone.transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {        
        var transform = bar.transform as RectTransform;

        if (right)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && correct) 
        {
            score += 5;

            size = size - size / 10;

            speed = speed * 1.5f;

            correctZone.transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        } else if(Input.GetKeyDown(KeyCode.Space) && !correct)
        {
            errors++;
        }

        textScore.text = $"Score: {score}";
        textErrors.text = $"Errors: {errors}";

        if (errors >= 5)
        {
            finishGame();
        }
    }

    private void finishGame()
    {
        critter.GetComponent<ManageStats>().trainStrength(score * 1.0f / 10);
        Destroy(gameObject);
    }
}
