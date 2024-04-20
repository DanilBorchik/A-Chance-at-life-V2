using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DverVizualnaia : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DverkaOtkrivaska(float povorot)
    {
        transform.rotation = Quaternion.Euler(0f, povorot, 0f);
    }
}
