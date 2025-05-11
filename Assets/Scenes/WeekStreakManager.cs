using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class WeekStreakManager : MonoBehaviour
{
    public TextMeshProUGUI streakText;
    public Image flameIcon;
    public Transform daysContainer;
    public GameObject dayPrefab;

    private HashSet<DateTime> completedDays = new HashSet<DateTime>();

    void Start()
    {
        DateTime today = DateTime.Today;
        DateTime startWeek = GetStartOfWeek(today);
        for(int i = 0; i < today.Day - startWeek.Day; i++)
        {
            completedDays.Add(today.AddDays(-i-1));
        } 
        completedDays.Add(today);


        SetupWeekStreak();
    }

    void SetupWeekStreak()
    {
        foreach (Transform child in daysContainer)
        {
            Destroy(child.gameObject);
        }

        DateTime today = DateTime.Today;
        DateTime startOfWeek = GetStartOfWeek(today);

        int currentStreak = 12;
        bool streakBroken = false;

        for (int i = 0; i < 7; i++)
        {
            DateTime day = startOfWeek.AddDays(i);
            GameObject dayGO = Instantiate(dayPrefab, daysContainer);
            DayUI dayUI = dayGO.GetComponent<DayUI>();

            dayUI.SetDate(day);

            bool completed = completedDays.Contains(day);

            dayUI.SetCompleted(completed);

            if (day <= today)
            {
                if (completed && !streakBroken)
                {
                    currentStreak++;
                }
                else if (!completed)
                {
                    streakBroken = true;
                }
            }
        }

        streakText.text = currentStreak.ToString();
    }

    DateTime GetStartOfWeek(DateTime date)
    {
        int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
        return date.AddDays(-1 * diff).Date;
    }
}
