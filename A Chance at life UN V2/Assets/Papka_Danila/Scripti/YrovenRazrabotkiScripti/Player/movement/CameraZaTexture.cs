using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZaTexture : MonoBehaviour
{
    public float wishDistance = 2.6f;
    public Transform CameraAxisTransform;

    // Update is called once per frame
    void Update()
    {
        var ray = (transform.position - CameraAxisTransform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(CameraAxisTransform.position, ray, out hit, wishDistance))
        {
            if (hit.collider.gameObject)
            {
                transform.position = hit.point;
            }
        }
        else
        {
            transform.position = CameraAxisTransform.position + ray * wishDistance;
        }
    }
}
