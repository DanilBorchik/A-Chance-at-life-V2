using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    public float ColvoTopliva;
    public int MaxTopliva;

    public float _VsegoPatron;

    public int _Patroni;
    public int _MaxPatroni;
    private float _MaxPatronVstvole = 7;
    public float _PatroniVstvole;

    public float _colvoAptechek;
    public float _MaxColvoAptechek;

    public int _colvoBigAptechek;
    public int _colvoMediumAptechek;
    public int _colvoSmalAptechek;

    public RectTransform ColvoToplivaTransform;
    public GameObject ToplivoBar;
    public RectTransform _PatroniRectTransform;
    public InventarUI _InbentarUI;

    public PlayerHealth _PlayerHealth;

    private void Start()
    {
        LoadInventar();
        PoloskaTopliva();
        DrawPatroniBar();
        ProverkaPistolPatron();
        ProverkaAptechek();
    }

    private void LoadInventar()
    {
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
        ColvoTopliva = PlayerPrefs.GetFloat("ColvoTopliva", ColvoTopliva);
        _Patroni = PlayerPrefs.GetInt("ColvoPatron", _Patroni);
        _colvoBigAptechek = PlayerPrefs.GetInt("ColvoBigAptechek", _colvoBigAptechek);
        _colvoMediumAptechek = PlayerPrefs.GetInt("ColvoMediumAptechek", _colvoMediumAptechek);
        _colvoSmalAptechek = PlayerPrefs.GetInt("ColvoSmalAptechek", _colvoSmalAptechek);
        _colvoAptechek = PlayerPrefs.GetFloat("ColvoAptechek", _colvoAptechek);
    }

    private void Update()
    {
        Perezoradka();
        IspolzovanieAptechek();
        UborkaLishnih();
    }

    private void IspolzovanieAptechek()
    {
        if (_colvoBigAptechek != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _PlayerHealth.AddHealth(100);
                _colvoAptechek -= 1.5f;
                _colvoBigAptechek -= 1;
                ProverkaAptechek();
                PlayerPrefs.SetInt("ColvoBigAptechek", _colvoBigAptechek);
                PlayerPrefs.SetFloat("ColvoAptechek", _colvoAptechek);
            }
        }
        if (_colvoMediumAptechek != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _PlayerHealth.AddHealth(50);
                _colvoAptechek -= 1;
                _colvoMediumAptechek -= 1;
                ProverkaAptechek();
                PlayerPrefs.SetInt("ColvoMediumAptechek", _colvoMediumAptechek);
                PlayerPrefs.SetFloat("ColvoAptechek", _colvoAptechek);
            }
        }
        if (_colvoSmalAptechek != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _PlayerHealth.AddHealth(25);
                _colvoAptechek -= 0.5f;
                _colvoSmalAptechek -= 1;
                ProverkaAptechek();
                PlayerPrefs.SetInt("ColvoSmalAptechek", _colvoSmalAptechek);
                PlayerPrefs.SetFloat("ColvoAptechek", _colvoAptechek);
            }
        }
    }

    private void ProverkaPistolPatron()
    {
        if (_Patroni <= 0)
        {
            _InbentarUI._YpravlenieIcon(1, 1, false, 0);
        }
        if (_Patroni > 0)
        {
            _InbentarUI._YpravlenieIcon(1, 1, true, 0);
        }
    }
    private void ProverkaAptechek()
    {
        if (_colvoBigAptechek <= 0)
        {
            _InbentarUI._YpravlenieIcon(2, 1, false, 0);
        }
        if (_colvoBigAptechek > 0)
        {
            _InbentarUI._YpravlenieIcon(2, 1, true, 0);
        }
        if (_colvoMediumAptechek <= 0)
        {
            _InbentarUI._YpravlenieIcon(2, 2, false, 1);
        }
        if (_colvoMediumAptechek > 0)
        {
            _InbentarUI._YpravlenieIcon(2, 2, true, 1);
        }
        if (_colvoSmalAptechek <= 0)
        {
            _InbentarUI._YpravlenieIcon(2, 3, false, 2);
        }
        if (_colvoSmalAptechek > 0)
        {
            _InbentarUI._YpravlenieIcon(2, 3, true, 2);
        }
    }

    private void UborkaLishnih()
    {
        if (_Patroni > _MaxPatroni)
        {
            _Patroni = _MaxPatroni;
        }
        ProverkaPistolPatron();
    }

    private void Perezoradka()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            while (_PatroniVstvole < 7 && _Patroni > 0)
            {
                _PatroniVstvole += 1;
                _Patroni -= 1;
            }
            ProverkaPistolPatron();
            PlayerPrefs.SetInt("ColvoPatron", _Patroni);
            DrawPatroniBar();
        }
    }
    public void AddPatroni(int colvo)
    {   
        _Patroni += colvo;
        PlayerPrefs.SetInt("ColvoPatron", _Patroni);
        ProverkaPistolPatron();
    }
    public void AddAptechki(int typeAptechki)
    {
        if(typeAptechki == 1)
        {
            _colvoBigAptechek += 1;
            PlayerPrefs.SetInt("ColvoBigAptechek", _colvoBigAptechek);
            _colvoAptechek += 1.5f;
        }
        if (typeAptechki == 2)
        {
            _colvoMediumAptechek += 1;
            PlayerPrefs.SetInt("ColvoMediumAptechek", _colvoMediumAptechek);
            _colvoAptechek += 1;
        }
        if (typeAptechki == 3)
        {
            _colvoSmalAptechek += 1;
            PlayerPrefs.SetInt("ColvoSmalAptechek", _colvoSmalAptechek);
            _colvoAptechek += 0.5f;
        }
        PlayerPrefs.SetFloat("ColvoAptechek", _colvoAptechek);
        ProverkaAptechek();
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