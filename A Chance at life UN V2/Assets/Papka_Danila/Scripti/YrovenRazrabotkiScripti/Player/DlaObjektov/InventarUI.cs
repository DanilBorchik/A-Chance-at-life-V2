using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventarUI : MonoBehaviour
{
    [SerializeField] GameObject _Inventar;
    [SerializeField] GameObject _Veshi;
    [SerializeField] GameObject _Tetrad;
    [SerializeField] List<GameObject> _AmmoIcon;
    [SerializeField] List<GameObject> _HealsIcon;
    [SerializeField] TextMeshProUGUI _colvoPatronPistol;

    public Inventar _InventarScript;
    public Strelba _Strelba;
    public PovorotCameri _PovorotCameri;

    private bool _InventarVkL = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_InventarVkL)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        _Inventar.SetActive(true);
        Time.timeScale = 0;
        _InventarVkL = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _PovorotCameri.enabled = false;
        _Strelba.enabled = false;
    }
    public void ResumeGame()
    {
        _Inventar.SetActive(false);
        Time.timeScale = 1;
        _InventarVkL = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _PovorotCameri.enabled = true;
        _Strelba.enabled = true;
    }
    public void Veshi()
    {
        _Veshi.SetActive(true);
        _Tetrad.SetActive(false);
    }
    public void Tetrad()
    {
        _Veshi.SetActive(false);
        _Tetrad.SetActive(true);
    }
    public void _YpravlenieIcon(int type, bool sostoianie, int num)
    {
        var _numberAmmo = _AmmoIcon[num];
        var _numberHeals = _HealsIcon[num];
        if (type == 1)
        {
            if (sostoianie == true)
            {
                _numberAmmo.SetActive(true);
                _colvoPatronPistol.text = "" + _InventarScript._Patroni;
            }
            else
            {
                _numberAmmo.SetActive(false);
            }
        }
        if(type == 2)
        {
            if (sostoianie == true)
            {
                _numberHeals.SetActive(true);
            }
            else
            {
                _numberHeals.SetActive(false);
            }
        }
    }
}
