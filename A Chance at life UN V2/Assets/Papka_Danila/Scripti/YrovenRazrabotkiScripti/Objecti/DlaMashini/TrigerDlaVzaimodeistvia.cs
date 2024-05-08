using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDlaVzaimodeistvia : MonoBehaviour
{
    public Car _Car;
    public GameObject _UIVzaimodeistvia;
    public Inventar inventar;

    private bool Ystanovleno;
    private int ColvoShin;

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
        if (_PeredvizhenieIgroka != null)
        {
            if (inventar.ColvoShin != 0)
            {
                _UIVzaimodeistvia.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _Car.BusRecovery(KakoyNamber);
                    Ystanovleno = true;
                    inventar.ColvoShin -= 1;
                    ColvoShin = inventar.ColvoShin;
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
