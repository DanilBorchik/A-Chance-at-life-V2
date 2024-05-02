using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForCar : MonoBehaviour
{
    public Inventar inventar;

    public GameObject _UIVzaimodeistvia;
    public GameObject _UIVzaimodeistviaFalse;

    public GameObject _Shina;

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        if (_PeredvizhenieIgroka != null)
        {
            if (inventar.ColvoShin == 0)
            {
                _UIVzaimodeistvia.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventar.ColvoShin += 1;
                    Destroy(_Shina);
                }
            }
            else
            {
                _UIVzaimodeistviaFalse.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (_PeredvizhenieIgroka != null)
        {
            if (inventar.ColvoShin == 0)
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
