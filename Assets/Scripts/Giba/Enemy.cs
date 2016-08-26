﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{

    NavMeshAgent pathFinder;
    Transform target;

    // Use this for initialization
    protected override void Start() {

        base.Start();

        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update() {



    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead){
                pathFinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }

    }
}
