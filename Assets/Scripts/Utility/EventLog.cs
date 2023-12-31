using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventLog : MonoBehaviour
{
    private static EventLog _instance;

    public static EventLog Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(EventLog)) as EventLog;

                if (!_instance)
                {
                    Debug.LogError("There needs to be exactly one active EventLog script on a GameObject in your scene.");
                }
            }

            return _instance;
        }
    }

    public static void Log(string logMessage, Color color)
    {
        Instance.AddLog(logMessage, color);
    }

    public static void LogInfo(string logMessage)
    {
        Instance.AddLog(logMessage, Color.white);
    }

    public static void LogError(string logMessage)
    {
        Instance.AddLog(logMessage, Color.red);
    }

    public GameObject eventLogTextPrefab;
    public RectTransform contentRectTransform;
    public float logLifetimeSeconds;

    public void AddLog(string logMessage, Color color)
    {
        GameObject newLogObject = Instantiate(eventLogTextPrefab);
        newLogObject.transform.SetParent(contentRectTransform, false);
        newLogObject.transform.SetSiblingIndex(0);

        TextMeshProUGUI newLogText = newLogObject.GetComponent<TextMeshProUGUI>();
        newLogText.text = logMessage;
        newLogText.color = color;

        Destroy(newLogObject, logLifetimeSeconds);
    }
}
