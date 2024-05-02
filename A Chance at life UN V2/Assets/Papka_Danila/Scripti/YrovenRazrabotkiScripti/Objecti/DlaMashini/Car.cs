using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public List<GameObject> tyre;

    public void BusRecovery(int number)
    {
        var _numberTyre = tyre[number];
        if (number == 0)
        {
            _numberTyre.SetActive(true);
        }
        if (number == 1)
        {
            _numberTyre.SetActive(true);
        }
        if (number == 2)
        {
            _numberTyre.SetActive(true);
        }
        if (number == 3)
        {
            _numberTyre.SetActive(true);
        }
    }
}
