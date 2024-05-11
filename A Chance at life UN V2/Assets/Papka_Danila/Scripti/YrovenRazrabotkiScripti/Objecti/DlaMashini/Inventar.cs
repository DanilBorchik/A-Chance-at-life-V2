using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    public float ColvoTopliva;
    public int MaxTopliva;

    private void Start()
    {
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
    }
    private void Update()
    {
        
    }
    public void Napolnenie(int ScolkoTopliva)
    {
        ColvoTopliva += ScolkoTopliva * Time.deltaTime;
    }
    public void ZapravkaMashini()
    {
        ColvoTopliva -= 5f * Time.deltaTime;
    }
}