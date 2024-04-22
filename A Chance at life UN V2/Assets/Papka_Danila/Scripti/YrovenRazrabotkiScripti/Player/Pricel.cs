﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pricel : MonoBehaviour
{
    public Transform targetPoint;
    public Camera CameraLink;
    public PeredvizhenieIgroka player;
    public float InSkyDistance;
    void Start()
    {
        yborka();
    }
    private void yborka()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        RayRay();
        transform.LookAt(targetPoint.position);
    }
    private void RayRay()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.55f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject != player.gameObject)
            {
                targetPoint.position = hit.point;
            }
        }
        else
        {
            targetPoint.position = ray.GetPoint(InSkyDistance);
        }
    }
}
