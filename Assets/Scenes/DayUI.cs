using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class DayUI : MonoBehaviour
{
    public TextMeshProUGUI dayNumberText;
    public TextMeshProUGUI dayText;
    public Image checkmarkImage;

    public void SetDate(DateTime dayNumber)
    {
        dayNumberText.text = dayNumber.Day.ToString();
        dayText.text = dayNumber.DayOfWeek.ToString().Substring(0,3);
    }

    public void SetCompleted(bool completed)
    {
        checkmarkImage.enabled = completed;
        dayNumberText.enabled = !completed;
    }

}
