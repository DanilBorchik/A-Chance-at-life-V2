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
    private int ColvoShin = 0;
    private int ColvoKanistr = 0;
    private float ColvoTopliva = 0;
    private float ColvoToplivaMashini = 0;

    private void Start()
    {
        _tyrebool = PlayerPrefs.GetInt("tyrebool", _tyrebool);
        _tyrebool1 = PlayerPrefs.GetInt("tyrebool1", _tyrebool1);
        _tyrebool2 = PlayerPrefs.GetInt("tyrebool2", _tyrebool2);
        _tyrebool3 = PlayerPrefs.GetInt("tyrebool3", _tyrebool3);
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
        ColvoTopliva = PlayerPrefs.GetFloat("ColvoTopliva", ColvoTopliva);
        ColvoToplivaMashini = PlayerPrefs.GetFloat("ColvoToplivaMashini", ColvoToplivaMashini);
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
        if (ColvoShin != 0)
        {
            EstProgress = true;
        }
        if (ColvoShin != 0)
        {
            EstProgress = true;
        }
        if (ColvoKanistr != 0)
        {
            EstProgress = true;
        }
        if (ColvoKanistr != 0)
        {
            EstProgress = true;
        }
        if (ColvoTopliva != 0)
        {
            EstProgress = true;
        }
        if (ColvoToplivaMashini != 0)
        {
            EstProgress = true;
        }
    }
    public void StartGameButton()
    {
        if (EstProgress == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
