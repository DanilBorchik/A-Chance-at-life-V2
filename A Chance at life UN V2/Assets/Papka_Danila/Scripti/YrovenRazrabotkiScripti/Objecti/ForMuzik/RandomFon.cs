using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFon : MonoBehaviour
{
    public List<AudioSource> _Fon;
    void Start()
    {
        _Fon[Random.Range(0, _Fon.Count)].Play();
    }
}
