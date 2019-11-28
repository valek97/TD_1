﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 2f;
    public float MaxLife = 100f;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex = -1;
    private float life;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.Find("WayPoint").transform;
        NextWaypoint();

        life = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = waypoint.transform.position - transform.position;
        dir.y = 0;

        float _speed = Time.deltaTime * speed;
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        if (dir.magnitude <= _speed)
        {
            NextWaypoint();
        }

    }

    void NextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.childCount)
        {
            waypointIndex = 0;
            Destroy(gameObject);
            return;
        }
        waypoint = waypoints.GetChild(waypointIndex);
    }

    public void SetDamage(float value)
    {
        life -= value;
        if (life <= 0 )
        {
            Destroy(gameObject);
        }
    }

}
