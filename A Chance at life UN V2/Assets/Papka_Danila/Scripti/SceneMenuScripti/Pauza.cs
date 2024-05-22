using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pauza : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    public Strelba _Strelba;
    public PovorotCameri _PovorotCameri;

    public Car _Car;

    bool _isPaused = false;
    public bool DomGG;
    public bool ForVin;
    private void Update()
    {
        if (ForVin == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }
    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _PovorotCameri.enabled = false;
        if (DomGG == false)
        {
            _Strelba.enabled = false;
        }

    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _PovorotCameri.enabled = true;
        if (ForVin == true)
        {
            _Car.Otmena = true;
        }
        if (DomGG == false)
        {
            _Strelba.enabled = true;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        _isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
