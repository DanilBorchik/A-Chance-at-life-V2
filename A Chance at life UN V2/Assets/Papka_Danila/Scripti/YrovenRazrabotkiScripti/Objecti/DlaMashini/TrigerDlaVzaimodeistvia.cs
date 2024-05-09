using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDlaVzaimodeistvia : MonoBehaviour
{
    public Car _Car;
    public GameObject _UIVzaimodeistvia;

    private int ColvoShin;

    public int KakoyNamber;
    public float ColvoToplivaMashini;

    public int DlaChegoTriger;


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
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _Car.BusRecovery(KakoyNamber);
                        _Inventar.ColvoShin -= 1;
                        ColvoShin = _Inventar.ColvoShin;
                        PlayerPrefs.SetInt("ColvoShin", ColvoShin);
                    }
                }
            }
            if (DlaChegoTriger == 2)
            {
                if (_Inventar.ColvoKanistr != 0)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        if (_Inventar.ColvoTopliva > 0.3)
                        {
                            _Inventar.ZapravkaMashini();
                            ColvoToplivaMashini += 5f * Time.deltaTime;
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (DlaChegoTriger == 1)
        {
            if (_PeredvizhenieIgroka != null)
            {
                _UIVzaimodeistvia.SetActive(false);
            }
        }
    }
}
