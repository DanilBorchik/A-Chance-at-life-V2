using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForCar : MonoBehaviour
{
    public GameObject _UIVzaimodeistvia;
    public GameObject _UIVzaimodeistviaFalse;
    public Inventar _InventarOnTriger;

    public int TypeObject;
    public bool podnal;
    public int num;

    private int ColvoShin;
    private int ColvoKanistr;
    private int sostoianie;

    public GameObject _Object;

    private void Start()
    {
        sostoianie = PlayerPrefs.GetInt("Sostoianie" + num, sostoianie);
        if (sostoianie == 1)
        {
            _Object.SetActive(false);
        }
    }
    private void Update()
    {
        if (podnal == true)
        {
            sostoianie = 1;
            PlayerPrefs.SetInt("Sostoianie" + num, sostoianie);
            podnal = false;
            _InventarOnTriger.StartSoundForObjectCar();
        }
        if (sostoianie == 1)
        {
            _Object.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        _InventarOnTriger = _Inventar;
        if (_PeredvizhenieIgroka != null)
        {
            if (TypeObject == 1)
            {
                if (_Inventar.ColvoShin == 0)
                {
                    _UIVzaimodeistvia.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        _Inventar.ColvoShin += 1;
                        ColvoShin = _Inventar.ColvoShin;
                        PlayerPrefs.SetInt("ColvoShin", ColvoShin);
                        podnal = true;
                    }
                }
                else
                {
                    _UIVzaimodeistviaFalse.SetActive(true);
                }
            }
            if (TypeObject == 2)
            {
                if (_Inventar.ColvoKanistr == 0)
                {
                    _UIVzaimodeistvia.SetActive(true);
                    if (Input.GetKey(KeyCode.F))
                    {
                        _Inventar.ColvoKanistr += 1;
                        ColvoKanistr = _Inventar.ColvoKanistr;
                        PlayerPrefs.SetInt("ColvoKanistr", ColvoKanistr);
                        podnal = true;
                    }
                }
                else
                {
                    _UIVzaimodeistviaFalse.SetActive(true);
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _InventarIgroka = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (_InventarIgroka.ColvoShin == 0)
            {
                _UIVzaimodeistvia.SetActive(false);
            }
            else
            {
                _UIVzaimodeistviaFalse.SetActive(false);
            }
            if (_InventarIgroka.ColvoKanistr == 0)
            {
                _UIVzaimodeistvia.SetActive(false);
            }
            else
            {
                _UIVzaimodeistviaFalse.SetActive(false);
            }
        }
    }
}
