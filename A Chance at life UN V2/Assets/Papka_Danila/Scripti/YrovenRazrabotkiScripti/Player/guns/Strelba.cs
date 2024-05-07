using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelba : MonoBehaviour
{
    public Pyla PylaPrefab;
    public PeredvizhenieIgroka _PeredvizhenieIgroka;
    public PlayerHealth _PlayerHealth;
    public Animator _animator;

    private int NomerAnimaciiStrelbi;
    public bool Strelbi;
    private bool AnimationStrelbi;
    private float timerStrelbi;
    //public AudioSource Fireball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            }
        }
    }

    private void ypravlenieAnimaciamiStrelbi()
    {
        _animator.SetInteger("Shooting", NomerAnimaciiStrelbi);
        if (AnimationStrelbi == false)
        {
            _animator.SetBool("ShootingBool", false);
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
            if (_PlayerHealth._Patroni > 0)
            {
                Instantiate(PylaPrefab, transform.position, transform.rotation);
                _PlayerHealth.DealMinysPatroni(1);
                NomerAnimaciiStrelbi = 1;
                Strelbi = true;
                timerStrelbi = 0;
                AnimationStrelbi = true;
                _animator.SetBool("ShootingBool", true);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Strelbi = false;
            timerStrelbi = 0;
        }
    }
}
