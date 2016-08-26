﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerControllerG))]
[RequireComponent(typeof(GunController))]
public class PlayerG : LivingEntity {

    public float moveSpeed = 5;
    PlayerControllerG controller;
    GunController gunController;

    Camera viewCamera;

    // Use this for initialization
    protected override void Start(){

        base.Start();

        controller = GetComponent<PlayerControllerG>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update(){

        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance)){

            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);

        }

        // Weapon input
        if (Input.GetMouseButton(0))
        {

            gunController.Shoot();

        }

    }

}