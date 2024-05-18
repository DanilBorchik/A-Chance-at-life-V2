using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    public int _typeAptechki;
    public GameObject Corobka;
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if(_Inventar._colvoAptechek < _Inventar._MaxColvoAptechek)
            {
                _Inventar.AddAptechki(_typeAptechki);
                Destroy(Corobka);
            }
        }
    }
}
