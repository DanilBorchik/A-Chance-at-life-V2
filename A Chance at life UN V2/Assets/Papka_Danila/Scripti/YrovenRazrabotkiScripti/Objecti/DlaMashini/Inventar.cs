using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    public float ColvoTopliva;
    public int MaxTopliva;

    public RectTransform ColvoToplivaTransform;
    public GameObject ToplivoBar;

    private void Start()
    {
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
        PoloskaTopliva();
    }
    private void Update()
    {
        
    }
    public void Napolnenie(int ScolkoTopliva)
    {
        ColvoTopliva += ScolkoTopliva * Time.deltaTime;
        ToplivoBar.SetActive(true);
        PoloskaTopliva();
    }
    public void ZapravkaMashini()
    {
        ColvoTopliva -= 5f * Time.deltaTime;
        ToplivoBar.SetActive(true);
        PoloskaTopliva();
    }
    public void PoloskaTopliva()
    {
        ColvoToplivaTransform.anchorMax = new Vector2(ColvoTopliva / MaxTopliva, 1);
    }
}