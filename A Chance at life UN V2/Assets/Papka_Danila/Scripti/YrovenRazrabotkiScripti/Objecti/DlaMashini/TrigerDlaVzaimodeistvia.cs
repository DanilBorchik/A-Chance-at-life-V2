using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDlaVzaimodeistvia : MonoBehaviour
{
    public Car _Car;
    public GameObject _UIVzaimodeistvia;

    private int ColvoShin;
    private bool Ystanovleno;

    public int KakoyNamber;

    private void Update()
    {
        if (Ystanovleno == true)
        {
            _UIVzaimodeistvia.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (_Inventar.ColvoShin != 0)
            {
                _UIVzaimodeistvia.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _Car.BusRecovery(KakoyNamber);
                    Ystanovleno = true;
                    _Inventar.ColvoShin -= 1;
                    ColvoShin = _Inventar.ColvoShin;
                    PlayerPrefs.SetInt("ColvoShin", ColvoShin);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (_PeredvizhenieIgroka != null)
        {
            _UIVzaimodeistvia.SetActive(false);
        }
    }
}
