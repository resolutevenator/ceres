﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 1f;
    private Vector3 targetPosition;
    private Vector2 rotateVector;

    void Start()
    {    
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0)) {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotateVector = targetPosition - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            float rotateAngle = (Mathf.Atan2(rotateVector.y, rotateVector.x) * Mathf.Rad2Deg) - 90;
            Quaternion rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }
    }
}
