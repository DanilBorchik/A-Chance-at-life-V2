using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    public float ColvoTopliva;
    public int MaxTopliva;

    public int _Patroni;
    public int _MaxPatroni;
    private float _MaxPatronVstvole = 7;
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
        _Patroni = PlayerPrefs.GetInt("ColvoPatron", _Patroni);
    }

    private void Update()
    {
        Perezoradka();
        while (_Patroni > _MaxPatroni)
        {
            _Patroni -= 1;
        }
    }
    private void Perezoradka()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            while (_PatroniVstvole < 7 && _Patroni != 0)
            {
                _PatroniVstvole += 1;
                _Patroni -= 1;
            }
            PlayerPrefs.SetInt("ColvoPatron", _Patroni);
            DrawPatroniBar();
        }
    }
    public void AddPatroni(int colvo)
    {   
        _Patroni += colvo;
        PlayerPrefs.SetInt("ColvoPatron", _Patroni);
    }
    public void DealMinysPatroni()
    {
        _PatroniVstvole -= 1;
        DrawPatroniBar();
    }
    private void DrawPatroniBar()
    {
        _PatroniRectTransform.anchorMax = new Vector2(_PatroniVstvole / _MaxPatronVstvole, 1);
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