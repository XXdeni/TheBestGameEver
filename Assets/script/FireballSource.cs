﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Camera cameraLing;
    public Transform targetPoint;
    public float targetInSkyDistance;

    private void Update()
    {
       transform.LookAt(targetPoint.position);

        var ray = cameraLing.ViewportPointToRay(new Vector3(0.5f,0.7f,0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }
    }

   
}
