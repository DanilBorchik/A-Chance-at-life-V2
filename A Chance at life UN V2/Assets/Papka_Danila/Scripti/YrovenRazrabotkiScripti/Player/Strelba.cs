using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelba : MonoBehaviour
{
    public Pyla PylaPrefab;
    public PeredvizhenieIgroka _PeredvizhenieIgroka;
    public PlayerHealth _PlayerHealth;

    //public AudioSource Fireball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                if (_PlayerHealth._Patroni > 0)
                {
                    Instantiate(PylaPrefab, transform.position, transform.rotation);
                    _PlayerHealth.DealMinysPatroni(1);
                    //Fireball.Play();
                }
        }
    }
}
