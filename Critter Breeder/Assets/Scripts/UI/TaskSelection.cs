using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskSelection : MonoBehaviour
{
    [SerializeField]GameObject taskManager;

    private void Start()
    {
        taskManager = GameObject.FindGameObjectWithTag("Task Manager");
    }
    public void setActiveTask()
    {
        var taskCompletion = taskManager.GetComponent<TaskCompletion>();

        taskCompletion.task = gameObject.GetComponent<Task>();
        taskCompletion.taskObject = gameObject;
    }
}
