using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapravkaCanistri : MonoBehaviour
{
    public float ColvoTopliva;
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (_Inventar.ColvoKanistr != 0)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    if (_Inventar.ColvoTopliva <= _Inventar.MaxTopliva)
                    {
                        if (ColvoTopliva > 0.3)
                        {
                            _Inventar.Napolnenie(5);
                            ColvoTopliva -= 5 * Time.deltaTime;
                        }
                    }
                }
            }
        }
    }
}
