using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBlood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBlood", 2);
    }
    private void DestroyBlood()
    {
        Destroy(gameObject);
    }
}
