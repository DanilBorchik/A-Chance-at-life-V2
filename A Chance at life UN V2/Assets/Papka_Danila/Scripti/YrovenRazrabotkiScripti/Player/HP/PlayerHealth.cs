using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float _hp = 100;
    public float _ScocPatron;
    public float _Patroni;
    public RectTransform _hpRectTransform;
    public RectTransform _PatroniRectTransform;
    public GameObject Players;

    public Pricel pricel;
    public GameObject gameplayUI;
    public GameObject gameOverScren;
    //public GameObject stvol;
    //public Animator _animator;
    //public AudioSource HitSound;
    //public AudioSource DeadSound;

    private float _maxhp;
    public bool _OnYmer = false;

    private void Start()
    {
        MaxChegoto();
    }
    private void Update()
    {
        if (_OnYmer == true)
        {
            Invoke("toMainMenu", 3);
        }
    }
    private void MaxChegoto()
    {
        _maxhp = _hp;
    }

    public bool IsAlive()
    {
        return _hp > 0;
    }

    public void DealDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            if (_OnYmer != true)
            {
                ded();
                //_animator.SetBool("Death", true);
            }
        }
        //if (_OnYmer != true)
        //{
            //HitSound.Play();
        //}
        DrawHealthBar();
    }
    public void DealMinysPatroni(float minys)
    {
        _Patroni -= minys;
        DrawPatroniBar();
    }
    private void ded()
    {
        gameplayUI.SetActive(false);
        gameOverScren.SetActive(true);
        //animator.SetTrigger("death");

        GetComponent<PeredvizhenieIgroka>().enabled = false;
        pricel.GetComponent<Strelba>().enabled = false;
        pricel.GetComponent<Pricel>().enabled = false;
        GetComponent<PovorotCameri>().enabled = false;

        Players.SetActive(false);
        //DeadSound.Play();
        _OnYmer = true;
    }
    public void toMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        _OnYmer = false;
    }
    private void DrawHealthBar()
    {
        _hpRectTransform.anchorMax = new Vector2(_hp / _maxhp, 1);
    }
    private void DrawPatroniBar()
    {
        _PatroniRectTransform.anchorMax = new Vector2(_Patroni / _ScocPatron, 1);
    }
    public void HpRegen(float _hpregen)
    {
        //if (_hp <= _maxhp)
        //{
            //_hp += _hpregen;
        //}
        //DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        _hp += amount;
        _hp = Mathf.Clamp(_hp, 0, _maxhp);
        DrawHealthBar();
    }
}
