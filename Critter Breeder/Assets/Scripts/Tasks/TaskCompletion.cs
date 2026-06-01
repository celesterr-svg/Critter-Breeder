using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskCompletion : MonoBehaviour
{
    public GameObject critter;    
    public GameObject taskObject;
    public Task task;

    public void checkMeetsTarget()
    {
        if (critter == null || task == null)
        {
            return;
        }

        var critterStats = critter.GetComponent<ManageStats>();
        string skill = task.skill;
        float skillReq = task.skillValue;

        if (skillReq <= critterStats.getGenes(skill))
        {
            task.completion = true;
            taskObject.GetComponent<TaskUI>().setCompletionImage(true);
            taskObject.GetComponent<Button>().enabled = false;
            taskObject = null;
            task = null;
        } else 
        {
            taskObject.GetComponent<TaskUI>().setCompletionImage(false);
            taskObject.GetComponent<Button>().enabled = false;
            taskObject = null;
            task = null;
        }
    }
}
