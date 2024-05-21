using System.Collections;
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
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.55f, 3));
        Vector3 shotPosition = ray.GetPoint(2.6f);
        Ray shotRay = new Ray(shotPosition, ray.direction);
        RaycastHit hit;
        if (Physics.Raycast(shotRay, out hit, 100f))
        {
            if(hit.collider.gameObject != player.gameObject && !hit.collider.isTrigger)
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
