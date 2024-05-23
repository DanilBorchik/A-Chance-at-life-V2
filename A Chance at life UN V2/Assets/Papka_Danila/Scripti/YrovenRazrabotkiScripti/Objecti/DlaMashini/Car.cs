using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public List<GameObject> tyre;
    public List<GameObject> tyreTriger;
    public TrigerDlaVzaimodeistvia Toplivo;
    public InventarUI _InventarUI;

    public PovorotCameri _PovorotCameri;

    public GameObject VinUI;

    public float ColvoToplivaMashini;

    private int _tyrebool = 0;
    private int _tyrebool1 = 0;
    private int _tyrebool2 = 0;
    private int _tyrebool3 = 0;

    private int VinSave;
    private int VinSchet;
    private bool a;
    private bool b;
    private bool c;
    private bool d;
    private bool f;
    public bool Otmena;

    private void Update()
    {
        if (VinSave == 0)
        {
            ColesaVin();
            ToplivoVin();
        }
        Vin();
        Galochki();
    }

    private void Galochki()
    {
        if (ColvoToplivaMashini >= 150)
        {
            _InventarUI.ToplivoTrue();
        }
        if (_tyrebool == 1 && _tyrebool1 == 1 && _tyrebool2 == 1 && _tyrebool3 == 1)
        {
            _InventarUI.ShiniTrue();
        }
    }

    private void Vin()
    {
        if (VinSchet == 5)
        {
            if (Otmena == false)
            {
                VinUI.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _PovorotCameri.enabled = false;
                VinSave = 1;
                PlayerPrefs.SetInt("VinSave", VinSave);
            }
        }
    }

    private void ToplivoVin()
    {
        if (ColvoToplivaMashini >= 150)
        {
            if (a == false)
            {
                VinSchet += 1;
                a = true;
            }
        }
    }

    private void ColesaVin()
    {
        if (b == false)
        {
            if (_tyrebool == 1)
            {
                tyre[0].SetActive(true);
                tyreTriger[0].SetActive(false);
                VinSchet += 1;
                b = true;
            }
        }
        if (c == false)
        {
            if (_tyrebool1 == 1)
            {
                tyre[1].SetActive(true);
                tyreTriger[1].SetActive(false);
                VinSchet += 1;
                c = true;
            }
        }
        if (d == false)
        {
            if (_tyrebool2 == 1)
            {
                tyre[2].SetActive(true);
                tyreTriger[2].SetActive(false);
                VinSchet += 1;
                d = true;
            }
        }
        if (f == false)
        {
            if (_tyrebool3 == 1)
            {
                tyre[3].SetActive(true);
                tyreTriger[3].SetActive(false);
                VinSchet += 1;
                f = true;
            }
        }
    }

    private void Start()
    {
        SaveProgres();
    }

    private void SaveProgres()
    {
        VinSave = PlayerPrefs.GetInt("VinSave", VinSave);
        _tyrebool = PlayerPrefs.GetInt("tyrebool", _tyrebool);
        _tyrebool1 = PlayerPrefs.GetInt("tyrebool1", _tyrebool1);
        _tyrebool2 = PlayerPrefs.GetInt("tyrebool2", _tyrebool2);
        _tyrebool3 = PlayerPrefs.GetInt("tyrebool3", _tyrebool3);
        ColvoToplivaMashini = PlayerPrefs.GetFloat("ColvoToplivaMashini", ColvoToplivaMashini);
    }

    public void BusRecovery(int number)
    {
        var _numberTyre = tyre[number];
        if (number == 0)
        {
            _tyrebool = 1;
            PlayerPrefs.SetInt("tyrebool", _tyrebool);
            if (_tyrebool == 1)
            {
                _numberTyre.SetActive(true);
                tyreTriger[0].SetActive(false);
            }
        }
        if (number == 1)
        {
            _tyrebool1 = 1;
            PlayerPrefs.SetInt("tyrebool1", _tyrebool1);
            if (_tyrebool1 == 1)
            {
                _numberTyre.SetActive(true);
                tyreTriger[1].SetActive(false);
            }
        }
        if (number == 2)
        {
            _tyrebool2 = 1;
            PlayerPrefs.SetInt("tyrebool2", _tyrebool2);
            if (_tyrebool2 == 1)
            {
                _numberTyre.SetActive(true);
                tyreTriger[2].SetActive(false);
            }
        }
        if (number == 3)
        {
            _tyrebool3 = 1;
            PlayerPrefs.SetInt("tyrebool3", _tyrebool3);
            if (_tyrebool3 == 1)
            {
                _numberTyre.SetActive(true);
                tyreTriger[3].SetActive(false);
            }
        }
    }


}
