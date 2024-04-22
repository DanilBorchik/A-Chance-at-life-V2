using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //public float _hp = 100;
    public float _ScocPatron;
    public float _Patroni;
    //public RectTransform _hpRectTransform;
    public RectTransform _ManaRectTransform;

    //public GameObject gameplayUI;
    //public GameObject gameOverScren;
    //public GameObject stvol;
    //public Animator _animator;
    //public AudioSource HitSound;
    //public AudioSource DeadSound;

    //private float _maxhp;
    //public bool _OnYmer = false;

    private void Start()
    {
        //_maxhp = _hp;
        _Patroni = _ScocPatron;
        DrawHealthBar();
    }
    void Update()
    {
        regenmani();
    }

    private void regenmani()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _Patroni = _ScocPatron;
            DrawManaBar();
        }
    }

    public void DealDamage(float damage)
    {
        //_hp -= damage;
        //if (_hp <= 0)
        //{
            //if (_OnYmer != true)
            //{
                //ded();
                //_animator.SetBool("Death", true);
            //}
        //}
        //if (_OnYmer != true)
        //{
            //HitSound.Play();
        //}
        //DrawHealthBar();
    }
    public void DealMinysPatroni(float minys)
    {
        _Patroni -= minys;
        DrawManaBar();
    }
    private void ded()
    {
        //gameplayUI.SetActive(false);
        //gameOverScren.SetActive(true);
        //stvol.GetComponent<CasterFireball>().enabled = false;
        //stvol.GetComponent<CastYmenshenie>().enabled = false;
        //GetComponent<brodilna>().enabled = false;
        //GetComponent<Nogi>().enabled = false;
        //DeadSound.Play();
        //_OnYmer = true;
    }
    private void DrawHealthBar()
    {
        //_hpRectTransform.anchorMax = new Vector2(_hp / _maxhp, 1);
    }
    private void DrawManaBar()
    {
        _ManaRectTransform.anchorMax = new Vector2(_Patroni / _ScocPatron, 1);
    }
    public void HpRegen(float _hpregen)
    {
        //if (_hp <= _maxhp)
        //{
            //_hp += _hpregen;
        //}
        //DrawHealthBar();
    }
}
