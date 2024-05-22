using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDlaVzaimodeistvia : MonoBehaviour
{
    public Car _Car;
    public GameObject _UIVzaimodeistvia;
    public GameObject _UIVzaimodeistviaV2;
    public GameObject _UIKanistriNet;
    public Inventar _Inventar;

    private int ColvoShin;
    private bool _PlayerTrigere;

    public int KakoyNamber;
    public float ColvoToplivaMashini;

    public int DlaChegoTriger;

    private void Start()
    {
        ColvoToplivaMashini = PlayerPrefs.GetFloat("ColvoToplivaMashini", ColvoToplivaMashini);
    }
    private void Update()
    {
        if (_PlayerTrigere == true)
        {
            if (DlaChegoTriger == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _Car.BusRecovery(KakoyNamber);
                    _Inventar.ColvoShin -= 1;
                    ColvoShin = _Inventar.ColvoShin;
                    PlayerPrefs.SetInt("ColvoShin", ColvoShin);
                }
            }
            if (DlaChegoTriger == 2)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    if (_Inventar.ColvoTopliva > 0.3)
                    {
                        _Inventar.ZapravkaMashini();
                        ColvoToplivaMashini += 5f * Time.deltaTime;
                        PlayerPrefs.SetFloat("ColvoToplivaMashini", ColvoToplivaMashini);
                    }
                }
            }
        }
        _Car.ColvoToplivaMashini = ColvoToplivaMashini;
    }

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (DlaChegoTriger == 1)
            {
                if (_Inventar.ColvoShin != 0)
                {
                    _UIVzaimodeistvia.SetActive(true);
                    _PlayerTrigere = true;
                }
            }
            if (DlaChegoTriger == 2)
            {
                if (_Inventar.ColvoKanistr != 0)
                {
                    if ( _Inventar.ColvoTopliva > 0.3)
                    {
                        _UIVzaimodeistvia.SetActive(true);
                        _PlayerTrigere = true;
                    }
                    else
                    {
                        _UIVzaimodeistviaV2.SetActive(true);
                        _Inventar.ToplivoBar.SetActive(true);
                        _UIVzaimodeistvia.SetActive(false);
                    }
                }
                else
                {
                    _UIKanistriNet.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();

        if (_PeredvizhenieIgroka != null)
        {
            _PlayerTrigere = false;
            _Inventar.ToplivoBar.SetActive(false);
            _UIVzaimodeistvia.SetActive(false);
            if (DlaChegoTriger == 2)
            {
                _UIVzaimodeistviaV2.SetActive(false);
                //_UIKanistriNet.SetActive(false);
            }
        }
    }
}
