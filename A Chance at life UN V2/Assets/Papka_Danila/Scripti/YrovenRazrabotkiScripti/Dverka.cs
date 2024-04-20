using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dverka : MonoBehaviour
{
    public DverVizualnaia DverkaViz;
    public GameObject _VizualVzaimodeistvia;
    public GameObject _VizualVzaimodeistviaZakrit;

    private bool Otkrita;
    private void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();

        if (Otkrita == false)
        {
            if (_PeredvizhenieIgroka != null)
            {
                _VizualVzaimodeistvia.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    DverkaViz.DverkaOtkrivaska(90);
                    _VizualVzaimodeistvia.SetActive(false);
                    Otkrita = true;
                }
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
                if (Input.GetKeyDown(KeyCode.F))
                {
                    DverkaViz.DverkaOtkrivaska(0);
                    _VizualVzaimodeistviaZakrit.SetActive(false);
                    Otkrita = false;
                }
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
        }
    }
}
