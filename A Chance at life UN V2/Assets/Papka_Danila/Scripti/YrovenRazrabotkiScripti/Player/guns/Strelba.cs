using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelba : MonoBehaviour
{
    public Pyla PylaPrefab;
    public PeredvizhenieIgroka _PeredvizhenieIgroka;
    public Inventar _Inventar;
    public Animator _animator;
    public AudioSource ShootFalse;

    private int NomerAnimaciiStrelbi;
    public bool Strelbi;
    private bool AnimationStrelbi;
    private float timerStrelbi;
    private float timerStrelbi1;

    void Start()
    {

    }
    void Update()
    {
        ypravlenieAnimaciamiStrelbi();
        VistrelPistoleta();
        if(Strelbi == true)
        {
            timerStrelbi += Time.deltaTime;
            if(timerStrelbi > 5f)
            {
                Strelbi = false;
                timerStrelbi = 0;
            }
        }
    }

    private void ypravlenieAnimaciamiStrelbi()
    {
        _animator.SetInteger("Shooting", NomerAnimaciiStrelbi);
        if (AnimationStrelbi == false)
        {
            timerStrelbi1 += Time.deltaTime;
            if (timerStrelbi1 >= 0.3f)
            {
                _animator.SetBool("ShootingBool", false);
                timerStrelbi1 = 0;
            }
        }
    }

    private void VistrelPistoleta()
    {
        AnimationStrelbi = false;
        if(Strelbi == false)
        {
            NomerAnimaciiStrelbi = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (_Inventar._PatroniVstvole > 0)
            {
                Instantiate(PylaPrefab, transform.position, transform.rotation);
                _Inventar.DealMinysPatroni();
                NomerAnimaciiStrelbi = 1;
                Strelbi = true;
                timerStrelbi = 0;
                AnimationStrelbi = true;
                _animator.SetBool("ShootingBool", true);
            }
            else
            {
                ShootFalse.Play();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Strelbi = false;
            timerStrelbi = 0;
        }
    }
}
