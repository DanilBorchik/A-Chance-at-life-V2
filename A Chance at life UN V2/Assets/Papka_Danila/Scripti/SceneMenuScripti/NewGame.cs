using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void NewGameButton()
    {
        PlayerPrefs.SetInt("tyrebool", 0);
        PlayerPrefs.SetInt("tyrebool1", 0);
        PlayerPrefs.SetInt("tyrebool2", 0);
        PlayerPrefs.SetInt("tyrebool3", 0);
        PlayerPrefs.SetInt("ColvoKanistr", 0);
        PlayerPrefs.SetInt("ColvoShin", 0);
        PlayerPrefs.SetFloat("ColvoToplivaMashini", 0);
        PlayerPrefs.SetFloat("ColvoTopliva", 0);
        SceneManager.LoadScene(1);
    }
}
