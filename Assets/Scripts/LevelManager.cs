using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<Button> buttonList = new List<Button>();

    private int _activeLevelIndex =1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCompletedLevels();
        CheckAllButtons();
       
    }

    private void CheckAllButtons()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (_activeLevelIndex >= buttonList[i].GetComponent<ButtonController>().buttonValue)
            {
                buttonList[i].GetComponent<ButtonController>().SetLockState();
            }
        }
    }

    private void LoadCompletedLevels()
    {
        if (PlayerPrefs.GetInt("ActiveLevelIndex") == 0)
        {
            _activeLevelIndex = 1;
        }
        else
        {
            _activeLevelIndex = PlayerPrefs.GetInt("ActiveLevelIndex");
        }
    }

    public void SaveActiveLevelIndex()
    {
        _activeLevelIndex++;
        
        PlayerPrefs.SetInt("ActiveLevelIndex", _activeLevelIndex);
    }
    
    
    [ContextMenu("Clear")]
    public void Clear(){
        PlayerPrefs.DeleteKey("ActiveLevelIndex");
    }
}
