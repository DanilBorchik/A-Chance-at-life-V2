using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelba : MonoBehaviour
{
    public Pyla PylaPrefab;
    public PeredvizhenieIgroka _PeredvizhenieIgroka;
    float timer = 0f;
    public float timerDlaPubliki = 0.8f;
    public float CostManaF = 10;

    //public AudioSource Fireball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timer >= timerDlaPubliki)
            {
                //if (_PeredvizhenieIgroka._mana >= CostManaF)
                //{
                    Instantiate(PylaPrefab, transform.position, transform.rotation);
                    timer = 0;
                    //Fireball.Play();
                //}
            }
        }
    }
}
