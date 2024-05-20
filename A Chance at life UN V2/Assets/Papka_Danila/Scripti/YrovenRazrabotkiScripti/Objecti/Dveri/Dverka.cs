using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dverka : MonoBehaviour
{
    public DverVizualnaia DverkaViz;
    public GameObject _VizualVzaimodeistvia;
    public GameObject _VizualVzaimodeistviaZakrit;
    public float povorotdveriOtkritie;
    public float povorotdveriZakritie;

    private bool Otkrita;
    private bool _PlayerTriger;
    private void Update()
    {
        if (_PlayerTriger == true)
        {
            if (Otkrita == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    DverkaViz.DverkaOtkrivaska(povorotdveriOtkritie);
                    _VizualVzaimodeistvia.SetActive(false);
                    Otkrita = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    DverkaViz.DverkaOtkrivaska(povorotdveriZakritie);
                    _VizualVzaimodeistviaZakrit.SetActive(false);
                    Otkrita = false;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (Otkrita == false)
        {
            if (_PeredvizhenieIgroka != null)
            {
                _VizualVzaimodeistvia.SetActive(true);
                _PlayerTriger = true;
            }
            else
            {
                _VizualVzaimodeistvia.SetActive(false);
            }
        }
        else
        {
            if (_PeredvizhenieIgroka != null)
            {
                _VizualVzaimodeistviaZakrit.SetActive(true);
                _PlayerTriger = true;
            }
            else
            {
                _VizualVzaimodeistvia.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (_PeredvizhenieIgroka != null)
        {
            _VizualVzaimodeistvia.SetActive(false);
            _VizualVzaimodeistviaZakrit.SetActive(false);
            _PlayerTriger = false;
        }
    }
}
