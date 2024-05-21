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
    [SerializeField] TextMeshProUGUI _colvoBigAptechek;
    [SerializeField] TextMeshProUGUI _colvoMediumAptechek;
    [SerializeField] TextMeshProUGUI _colvoSmalAptechek;

    public Inventar _InventarScript;
    public Strelba _Strelba;
    public PovorotCameri _PovorotCameri;

    public bool DomGG;

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
        if (DomGG == false)
        {
            _Strelba.enabled = false;
        }
    }
    public void ResumeGame()
    {
        _Inventar.SetActive(false);
        Time.timeScale = 1;
        _InventarVkL = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _PovorotCameri.enabled = true;
        if (DomGG == false)
        {
            _Strelba.enabled = true;
        }
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
    public void _YpravlenieIcon(int razdel, int type, bool sostoianie, int num)
    {
        if (razdel == 1)
        {
            var _numberAmmo = _AmmoIcon[num];
            if (type == 1)
            {
                SostoianieAmmo(sostoianie, _numberAmmo);
                _colvoPatronPistol.text = _InventarScript._Patroni.ToString();
            }
        }
        if (razdel == 2)
        {
            var _numberHeals = _HealsIcon[num];
            if (type == 1)
            {
                SosotoianieAptechki(sostoianie, _numberHeals);
                _colvoBigAptechek.text = _InventarScript._colvoBigAptechek.ToString();
            }
            if (type == 2)
            {
                SosotoianieAptechki(sostoianie, _numberHeals);
                _colvoMediumAptechek.text = _InventarScript._colvoMediumAptechek.ToString();
            }
            if (type == 3)
            {
                SosotoianieAptechki(sostoianie, _numberHeals);
                _colvoSmalAptechek.text = _InventarScript._colvoSmalAptechek.ToString();
            }
        }
    }

    private void SostoianieAmmo(bool sostoianie, GameObject _numberAmmo)
    {
        if (sostoianie == true)
        {
            _numberAmmo.SetActive(true);
        }
        else
        {
            _numberAmmo.SetActive(false);
        }
    }

    private static void SosotoianieAptechki(bool sostoianie, GameObject _numberHeals)
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
