using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCreator : MonoBehaviour
{
    [SerializeField] private GameObject sender;

    [Header("Task Settings")]

    [Space]
    public int taskAmount;

    [Space]
    public GameObject taskMenu;

    [Space]
    public List<string> skills = new List<string> 
    {
        "Strength",
        "Intelligence"
    };

    [Space]
    public float minValue;
    public float maxValue;

    [Space]
    public GameObject taskprefab;

    private void Start()
    {
        sender = GameObject.FindGameObjectWithTag("Day Progression");

        if (sender != null)
        {
            DayProgression dayProgression = sender.GetComponent<DayProgression>();
            dayProgression.OnDayAdvanced.AddListener(newDay);
        }

        for (int i = 0; i < taskAmount; i++)
        {
            createTask();
        }

    }

    private void newDay()
    {
        Destroy(GameObject.FindGameObjectWithTag("Task"));

        for (int i = 0; i < taskAmount; i++)
        {
            createTask();
        }
    }

    public void createTask()
    {
        var task = Instantiate(taskprefab, taskMenu.transform);        

        var taskValues = task.GetComponent<Task>();
        float skillVal = Random.Range(minValue, maxValue);

        taskValues.skill = skills[Random.Range(0, skills.Count)];
        taskValues.skillValue = Mathf.Round(skillVal * 100f) / 100f;
    }
}
