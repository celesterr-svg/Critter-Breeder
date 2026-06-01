using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] SpriteAtlas icons;
    [SerializeField] Task task;
    [SerializeField] Image taskImage;
    [SerializeField] Image taskResult;
    [SerializeField] TextMeshProUGUI taskBody;
    [SerializeField] TextMeshProUGUI taskLevel;    


    private void Start()
    {      
        taskImage.sprite = icons.GetSprite(task.skill);
        taskLevel.text = task.skillValue.ToString();
    }

    public void setCompletionImage(bool right)
    {
        if (right)
        {
            taskResult.sprite = icons.GetSprite("Correct");
        } else
        {
            taskResult.sprite = icons.GetSprite("Wrong");
        }
    }
}
