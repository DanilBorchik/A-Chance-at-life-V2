using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeremeshenieNaDrygyuLoky : MonoBehaviour
{
    public int Kyda;
    public bool DomGG = true;
    public GameObject VizualPotverzdenie;

    public PovorotCameri _PovorotCameri;
    public Strelba _Strelba;

    private bool _isPaused = false;
    private bool _OnVTrigere = false;
    private bool _Ne = false;
    private bool fortimer;
    private float timerFor_OnVTrigere;

    private void Update()
    {
        if (_OnVTrigere == true)
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
        if (fortimer == true)
        {
            timerFor_OnVTrigere += Time.deltaTime;
        }
        if (timerFor_OnVTrigere > 0.1f)
        {
            _OnVTrigere = false;
            fortimer = false;
            timerFor_OnVTrigere = 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        if (_PeredvizhenieIgroka != null)
        {
            if (_Ne == false)
            {
                _isPaused = true;
            }
            _OnVTrigere = true;
            fortimer = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        if (_PeredvizhenieIgroka != null)
        {
            _isPaused = false;
            _Ne = false;
            fortimer = true;
        }
    }
    public void loadSceny()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Kyda);
        _isPaused = false;
    }

    public void Ne()
    {
        _Ne = true;
        _isPaused = false;
    }

    public void PauseGame()
    {
        VizualPotverzdenie.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _PovorotCameri.enabled = true;
        if (DomGG == false)
        {
            _Strelba.enabled = true;
        }
    }

    public void ResumeGame()
    {
        VizualPotverzdenie.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _PovorotCameri.enabled = false;
        if (DomGG == false)
        {
            _Strelba.enabled = false;
        }
    }
}
