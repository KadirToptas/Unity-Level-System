using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private  Button levelButton;
    
    [SerializeField] private TMP_Text buttonText;

    [SerializeField] private GameObject lockIconObject;
    
    public int buttonValue;

    private bool _isCompleted;

    private void Start()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(LoadSelectedScene);
    }


    public void SetLockState()
    {
        _isCompleted = true;

        if (_isCompleted)
        {
            buttonText.text = buttonValue.ToString();
            lockIconObject.SetActive(false);
        }

        else
        {
            buttonText.text = "";
            lockIconObject.SetActive(true);
        }
    }

    public void LoadSelectedScene()
    {
        if (_isCompleted)
        {
            SceneManager.LoadScene(buttonValue);
        }
    }
}
