using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeremeshenieNaDrygyuLoky : MonoBehaviour
{
    public int Kyda;
    public void OnTriggerEnter(Collider other)
    {
        var _PeredvizhenieIgroka = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        if (_PeredvizhenieIgroka != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Kyda);
        }
    }
}
