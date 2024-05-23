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
        PlayerPrefs.SetInt("ColvoPatron", 0);
        PlayerPrefs.SetInt("ColvoBigAptechek", 0);
        PlayerPrefs.SetInt("ColvoMediumAptechek", 0);
        PlayerPrefs.SetInt("ColvoSmalAptechek", 0);
        PlayerPrefs.SetFloat("ColvoAptechek", 0);
        PlayerPrefs.SetInt("Sostoianie" + 1, 0);
        PlayerPrefs.SetInt("Sostoianie" + 2, 0);
        PlayerPrefs.SetInt("Sostoianie" + 3, 0);
        PlayerPrefs.SetInt("Sostoianie" + 4, 0);
        PlayerPrefs.SetInt("Sostoianie" + 5, 0);
        PlayerPrefs.SetFloat("ColvoToplivaInBochke" + 1, 50);
        PlayerPrefs.SetFloat("ColvoToplivaInBochke" + 2, 50);
        PlayerPrefs.SetFloat("ColvoToplivaInBochke" + 3, 50);
        PlayerPrefs.SetInt("VinSave", 0);
        SceneManager.LoadScene(1);
    }
}
