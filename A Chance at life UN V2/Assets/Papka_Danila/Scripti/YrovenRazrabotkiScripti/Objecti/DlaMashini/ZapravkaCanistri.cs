﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapravkaCanistri : MonoBehaviour
{
    public float ColvoTopliva;

    public Inventar _InventarForSound;

    public bool pysto;
    public int Number;

    public GameObject UIvzaimodeistvie;
    public GameObject UIvzaimodeistvieFalse;
    public GameObject UIvzaimodeistvieCanFalse;
    public GameObject UICanPerepolneno;

    private bool Nalivaem = false;

    private void Start()
    {
        ColvoTopliva = PlayerPrefs.GetFloat("ColvoToplivaInBochke" + Number, ColvoTopliva);
        if (ColvoTopliva < 0.1f)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (pysto == true)
        {
            PlayerPrefs.SetFloat("ColvoToplivaInBochke" + Number, ColvoTopliva);
            pysto = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        bool Active = false;
        _InventarForSound = _Inventar;
        if (_PeredvizhenieIgroka != null)
        {
            if (_Inventar.ColvoKanistr != 0)
            {
                if (ColvoTopliva <= 0)
                {
                    UIvzaimodeistvieFalse.SetActive(true);
                    UIvzaimodeistvie.SetActive(false);
                }
                else
                {
                    UIvzaimodeistvie.SetActive(true);
                }
                if (_Inventar.ColvoTopliva >= _Inventar.MaxTopliva)
                {
                    UICanPerepolneno.SetActive(true);
                    UIvzaimodeistvie.SetActive(false);
                }
                if (Input.GetKey(KeyCode.F))
                {
                    if (_Inventar.ColvoTopliva <= _Inventar.MaxTopliva)
                    {
                        if (ColvoTopliva >= 0)
                        {
                            _Inventar.Napolnenie(5);
                            ColvoTopliva -= 5 * Time.deltaTime;
                            Active = true;
                            if (!Nalivaem)
                            {
                                Nalivaem = true;
                                _InventarForSound.SoundForCanTrue();
                            }
                        }
                        else
                        {
                            pysto = true;
                        }
                    }
                }
            }
            else
            {
                UIvzaimodeistvieCanFalse.SetActive(true);
            }
        }
        if (!Active)
        {
            if (Nalivaem == true)
            {
                Nalivaem = false;
                _InventarForSound.SoundForCanFalse();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            UIvzaimodeistvieCanFalse.SetActive(false);
            UIvzaimodeistvie.SetActive(false);
            UICanPerepolneno.SetActive(false);
            UIvzaimodeistvieFalse.SetActive(false);
            _Inventar.ToplivoBar.SetActive(false);
            Nalivaem = false;
            _InventarForSound.SoundForCanFalse();
        }
    }
}
