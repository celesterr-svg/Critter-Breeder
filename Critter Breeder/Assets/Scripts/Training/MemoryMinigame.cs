using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryMinigame : MonoBehaviour
{
    [SerializeField] private List<string> originalSequence = new();
    [SerializeField] private List<string> answerSequence = new();

    [SerializeField] private int length;
    [SerializeField] private bool waitForAnswer;
    [SerializeField] private int correctLetters;
    [SerializeField] private int round = 1;
    [SerializeField] private int errors;

    public GameObject critter;

    [Header("Graphics")]
    public GameObject grid;
    public GameObject letterPrefab;
    public GameObject score;
    public GameObject currentRound;

    private void Start()
    {
        createSequence();
    }
    private void Update()
    {
        if (waitForAnswer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                answerSequence.Add("W");
                var letter = Instantiate(letterPrefab, grid.transform);
                letter.GetComponentInChildren<TextMeshProUGUI>().text = "W";
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                answerSequence.Add("A");
                var letter = Instantiate(letterPrefab, grid.transform);
                letter.GetComponentInChildren<TextMeshProUGUI>().text = "A";
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                answerSequence.Add("S");
                var letter = Instantiate(letterPrefab, grid.transform);
                letter.GetComponentInChildren<TextMeshProUGUI>().text = "S";
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                answerSequence.Add("D");
                var letter = Instantiate(letterPrefab, grid.transform);
                letter.GetComponentInChildren<TextMeshProUGUI>().text = "D";
            }
        }

        if (answerSequence.Count >= length)
        {
            waitForAnswer = false;
        }

        if (answerSequence.Count == originalSequence.Count) 
        {
            checkAnswer();
        }
    }

    private void createSequence()
    {
        for(int i = 1; i <= length; i++)
        {
            int letter = Random.Range(0, 4);

            switch (letter)
            {
                case 0:
                    originalSequence.Add("W");
                    break;
                case 1:
                    originalSequence.Add("A");
                    break;
                case 2:
                    originalSequence.Add("S");
                    break;
                case 3:
                    originalSequence.Add("D");
                    break;
            }
        }

        foreach (string str in originalSequence)
        {
            var letter = Instantiate(letterPrefab, grid.transform);

            letter.GetComponentInChildren<TextMeshProUGUI>().text = str;
        }

        StartCoroutine(seeAnswerDelay(5f));      
    }

    private void checkAnswer()
    {
        for (int i = 0; i < originalSequence.Count; i++)
        {
            if (answerSequence[i].Equals(originalSequence[i]))
            {
                correctLetters++;
            }
            else
            {
                errors++;
            }
        }

        round++;

        score.GetComponent<TextMeshProUGUI>().text = $"Score: {correctLetters}";
        currentRound.GetComponent<TextMeshProUGUI>().text = $"Round: {round}";

        resetMinigame();
    }

    private void resetMinigame()
    {
        if (errors >= 3)
        {
            finishGame();
        }
        answerSequence.Clear();
        originalSequence.Clear();

        EraseChildren(grid);

        createSequence();

        if(round % 5 == 0 && length < 11)
        {
            length++;
        }
    }

    private void EraseChildren(GameObject obj)
    {
        if (obj.transform.childCount == 0)
        {
            return;
        }

        for (int i = obj.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
    }

    private void finishGame()
    {
        critter.GetComponent<ManageStats>().trainIntelligence(correctLetters * 1.0f /10);
        Destroy(gameObject);
    }

    IEnumerator seeAnswerDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EraseChildren(grid);
        waitForAnswer = true;
    }
}
