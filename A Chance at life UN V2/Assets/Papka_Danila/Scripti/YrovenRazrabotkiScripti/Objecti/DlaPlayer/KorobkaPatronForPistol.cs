using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KorobkaPatronForPistol : MonoBehaviour
{
    public int HowPatron;
    public GameObject Corobka;

    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != false)
        {
            if( _Inventar._Patroni < _Inventar._MaxPatroni)
            {
                _Inventar.AddPatroni(HowPatron);
                Destroy(Corobka);
            }
        }
    }
}
