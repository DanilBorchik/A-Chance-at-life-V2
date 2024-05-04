using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool EstProgress;
    private int _tyrebool = 0;
    private int _tyrebool1 = 0;
    private int _tyrebool2 = 0;
    private int _tyrebool3 = 0;
    public void StartGameButton()
    {
        if (EstProgress == true)
        {
            SceneManager.LoadScene(1);
        }
        _tyrebool = PlayerPrefs.GetInt("tyrebool", _tyrebool);
        _tyrebool1 = PlayerPrefs.GetInt("tyrebool1", _tyrebool1);
        _tyrebool2 = PlayerPrefs.GetInt("tyrebool2", _tyrebool2);
        _tyrebool3 = PlayerPrefs.GetInt("tyrebool3", _tyrebool3);
        if (_tyrebool == 1)
        {
            EstProgress = true;
        }
        if (_tyrebool1 == 1)
        {
            EstProgress = true;
        }
        if (_tyrebool2 == 1)
        {
            EstProgress = true;
        }
        if (_tyrebool3 == 1)
        {
            EstProgress = true;
        }
    }
}
