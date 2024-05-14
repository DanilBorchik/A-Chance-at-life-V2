﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    public float ColvoTopliva;
    public int MaxTopliva;

    public float _MaxPatron;
    public float _PatroniVstvole;

    public RectTransform ColvoToplivaTransform;
    public GameObject ToplivoBar;
    public RectTransform _PatroniRectTransform;

    private void Start()
    {
        SaveInventar();
        PoloskaTopliva();
        DrawPatroniBar();
    }

    private void SaveInventar()
    {
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
        ColvoTopliva = PlayerPrefs.GetFloat("ColvoTopliva", ColvoTopliva);
    }

    private void Update()
    {
        Perezoradka();
    }
    private void Perezoradka()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _PatroniVstvole = _MaxPatron;
            DrawPatroniBar();
        }
    }
    public void DealMinysPatroni()
    {
        _PatroniVstvole -= 1;
        DrawPatroniBar();
    }
    private void DrawPatroniBar()
    {
        _PatroniRectTransform.anchorMax = new Vector2(_PatroniVstvole / _MaxPatron, 1);
    }
    public void Napolnenie(int ScolkoTopliva)
    {
        ColvoTopliva += ScolkoTopliva * Time.deltaTime;
        ToplivoBar.SetActive(true);
        PoloskaTopliva();
        PlayerPrefs.SetFloat("ColvoTopliva", ColvoTopliva);
    }
    public void ZapravkaMashini()
    {
        ColvoTopliva -= 5f * Time.deltaTime;
        ToplivoBar.SetActive(true);
        PoloskaTopliva();
        PlayerPrefs.SetFloat("ColvoTopliva", ColvoTopliva);
    }
    public void PoloskaTopliva()
    {
        ColvoToplivaTransform.anchorMax = new Vector2(ColvoTopliva / MaxTopliva, 1);
    }
}