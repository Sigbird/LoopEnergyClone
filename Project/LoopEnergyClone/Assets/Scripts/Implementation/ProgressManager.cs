using System;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    private const string LevelKey = "Level";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveProgress(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level);
        PlayerPrefs.Save();
    }

    public int LoadProgress()
    {
       
        if (PlayerPrefs.HasKey(LevelKey))
        {
            return PlayerPrefs.GetInt(LevelKey);
        }
        else
        {
            return 1;
        }
    }

    [ContextMenu("Clear Progresses")]
    private void ClearProgresses()
    {
        PlayerPrefs.DeleteAll();
    }
}
