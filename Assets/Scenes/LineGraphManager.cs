using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LineGraphManager : MonoBehaviour
{
    public RectTransform graphContainer;
    public Sprite circleSprite;
    public Color gridLineColor = new Color(0, 0, 0, 0.5f);

    void Start()
    {
        List<int> dataPoints = new List<int>() { 10, 5, 30, 40, 10, 40, 34 };
        ShowGraph(dataPoints);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        Image image = gameObject.GetComponent<Image>();
        image.sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        Image image = gameObject.GetComponent<Image>();
        image.color = new Color(0, 0, 1, 0.7f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }

    private GameObject CreateTextLabel(string text, Vector2 anchoredPosition)
    {
        GameObject textGameObject = new GameObject("label", typeof(TextMeshProUGUI));
        textGameObject.transform.SetParent(graphContainer, false);
        TextMeshProUGUI label = textGameObject.GetComponent<TextMeshProUGUI>();
        label.text = text;
        label.fontSize = 14;
        label.color = Color.black;
        label.alignment = TextAlignmentOptions.Center;

        RectTransform rectTransform = label.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(60, 20);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return textGameObject;
    }

    private void CreateHorizontalLine(float yPosition)
    {
        GameObject gameObject = new GameObject("gridLine", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        Image image = gameObject.GetComponent<Image>();
        image.color = gridLineColor;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(graphContainer.sizeDelta.x / 2, yPosition);
        rectTransform.sizeDelta = new Vector2(graphContainer.sizeDelta.x, 1f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    public void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float xSize = graphWidth / (valueList.Count - 1);

        int yLabelCount = 5;
        for (int i = 0; i <= yLabelCount; i++)
        {
            float normalizedValue = i / (float)yLabelCount;
            float yPosition = normalizedValue * graphHeight;
            string yLabel = (normalizedValue * 60).ToString("0");
            Vector2 labelPosition = new Vector2(-20f, yPosition);
            CreateTextLabel(yLabel, labelPosition);

            CreateHorizontalLine(yPosition);
        }

        string[] dayLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize * i;
            float yPosition = (valueList[i] / (float)60) * graphHeight;
            Vector2 circlePosition = new Vector2(xPosition, yPosition);
            GameObject circle = CreateCircle(circlePosition);

            string xLabel = dayLabels[i % dayLabels.Length];
            Vector2 labelPosition = new Vector2(xPosition, -30f);
            CreateTextLabel(xLabel, labelPosition);

            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circlePosition);
            }
            lastCircleGameObject = circle;
        }
    }
}