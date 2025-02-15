﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPartController : MonoBehaviour
{

    private Rigidbody rigidBody;
    private MeshRenderer meshRender;
    private StackController stackController;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        meshRender = GetComponent<MeshRenderer>();
        stackController = transform.parent.GetComponent<StackController>();
        
    }
    public void Shatter()
   {
        rigidBody.isKinematic = false;
        GetComponent<Collider>().enabled = false;

        Vector3 forcePoint = transform.parent.position;
        float paretXpos = transform.parent.position.x;
        float xPos = meshRender.bounds.center.x;

        Vector3 subDir = (paretXpos - xPos < 0) ? Vector3.right : Vector3.left;
        Vector3 dir = (Vector3.up * 1.5f + subDir).normalized;

        float force = Random.Range(20, 35);
        float torque = Random.Range(110, 180);

        rigidBody.AddForceAtPosition(dir * force, forcePoint, ForceMode.Impulse);
        rigidBody.AddTorque(Vector3.left * torque);
        rigidBody.velocity = Vector3.down;
   }
   

}
