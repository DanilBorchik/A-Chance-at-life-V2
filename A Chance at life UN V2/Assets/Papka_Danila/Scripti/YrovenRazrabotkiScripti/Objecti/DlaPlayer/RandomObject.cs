using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public List<GameObject> objectsiForPlayer;
    void Start()
    {
        dlaobject();
    }
    private void dlaobject()
    {
        for (int j = 0; j < objectsiForPlayer.Count; j++)
        {
            objectsiForPlayer[j].SetActive(System.Convert.ToBoolean(Random.Range(0, 2)));
        }
    }
}
