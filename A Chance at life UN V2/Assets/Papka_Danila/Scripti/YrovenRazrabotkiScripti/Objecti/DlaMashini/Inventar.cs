using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public int ColvoShin;
    public int ColvoKanistr;

    private void Start()
    {
        ColvoShin = PlayerPrefs.GetInt("ColvoShin", ColvoShin);
        ColvoKanistr = PlayerPrefs.GetInt("ColvoKanistr", ColvoKanistr);
    }
}