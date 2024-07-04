using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletedController : MonoBehaviour
{
    private Button _levelCompleteButton;
    
    
    private void Start()
    {
        _levelCompleteButton = GetComponent<Button>();
        _levelCompleteButton.onClick.AddListener(LevelComplete);
    }

    public void LevelComplete()
    {
        if (PlayerPrefs.GetInt("LevelIndex") <= SceneManager.GetActiveScene().buildIndex)
        {
            LevelManager.Instance.SaveActiveLevelIndex();
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
