using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapravkaCanistri : MonoBehaviour
{
    public float ColvoTopliva;

    public bool pysto;
    public int Number;

    public GameObject UIvzaimodeistvie;
    public GameObject UIvzaimodeistvieFalse;
    public GameObject UIvzaimodeistvieCanFalse;
    public GameObject UICanPerepolneno;

    private void Start()
    {
       //ColvoTopliva = PlayerPrefs.GetFloat("ColvoToplivaInBochke" + Number, ColvoTopliva);
        //if (ColvoTopliva < 0.3f)
        //{
            //gameObject.SetActive(false);
        //}
    }
    private void Update()
    {
        if (pysto == true)
        {
            PlayerPrefs.SetFloat("ColvoToplivaInBochke" + Number, ColvoTopliva);
            pysto = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            if (_Inventar.ColvoKanistr != 0)
            {
                if (ColvoTopliva < 0.3)
                {
                    UIvzaimodeistvieFalse.SetActive(true);
                    UIvzaimodeistvie.SetActive(false);
                }
                else
                {
                    UIvzaimodeistvie.SetActive(true);
                }
                if (_Inventar.ColvoTopliva >= _Inventar.MaxTopliva)
                {
                    UICanPerepolneno.SetActive(true);
                    UIvzaimodeistvie.SetActive(false);
                }
                if (Input.GetKey(KeyCode.F))
                {
                    if (_Inventar.ColvoTopliva <= _Inventar.MaxTopliva)
                    {
                        if (ColvoTopliva > 0.3)
                        {
                            _Inventar.Napolnenie(5);
                            ColvoTopliva -= 5 * Time.deltaTime;
                        }
                        else
                        {
                            pysto = true;
                        }
                    }
                }
            }
            else
            {
                UIvzaimodeistvieCanFalse.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        var _Inventar = other.gameObject.GetComponent<Inventar>();
        if (_PeredvizhenieIgroka != null)
        {
            UIvzaimodeistvieCanFalse.SetActive(false);
            UIvzaimodeistvie.SetActive(false);
            UICanPerepolneno.SetActive(false);
            UIvzaimodeistvieFalse.SetActive(false);
            _Inventar.ToplivoBar.SetActive(false);
        }
    }
}
