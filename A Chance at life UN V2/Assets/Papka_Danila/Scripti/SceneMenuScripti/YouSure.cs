using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSure : MonoBehaviour
{
    public GameObject _Menu;
    public GameObject _YouSure;
    public void Exit()
    {
        _Menu.SetActive(false);
        _YouSure.SetActive(true);
    }
    public void No()
    {
        _Menu.SetActive(true);
        _YouSure.SetActive(false);
    }
}
