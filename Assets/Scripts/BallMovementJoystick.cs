using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementJoystick : MonoBehaviour
{
    protected Joystick joystick;
    private ObstacleState obstacleStates;

    [HideInInspector]
    public int cancombiningAmount = 0;

    private float speed = 20;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        obstacleStates = FindObjectOfType<ObstacleState>();

        for (int i = 0; i < obstacleStates.transform.childCount; i++)
        {
            if (obstacleStates.transform.GetChild(i).GetComponent<CombinigColors>() == null)
            {
                cancombiningAmount++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);
    }
}
