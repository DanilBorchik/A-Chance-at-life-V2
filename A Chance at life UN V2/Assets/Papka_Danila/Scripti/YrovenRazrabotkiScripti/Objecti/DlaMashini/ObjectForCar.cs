using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForCar : MonoBehaviour
{
    public GameObject _UIVzaimodeistvia;
    public GameObject _UIVzaimodeistviaFalse;

    public int TypeObject;

    private int ColvoShin;
    private int ColvoKanistr;

    public GameObject _Object;

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (TypeObject == 1)
            {
                if (_Inventar.ColvoShin == 0)
                {
                    _UIVzaimodeistvia.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _Inventar.ColvoShin += 1;
                        ColvoShin = _Inventar.ColvoShin;
                        PlayerPrefs.SetInt("ColvoShin", ColvoShin);
                        Destroy(_Object);
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
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _Inventar.ColvoKanistr += 1;
                        ColvoKanistr = _Inventar.ColvoKanistr;
                        PlayerPrefs.SetInt("ColvoKanistr", ColvoKanistr);
                        Destroy(_Object);
                    }
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
