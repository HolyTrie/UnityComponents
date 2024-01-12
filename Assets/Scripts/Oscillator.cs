using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    Vector3 rotation_velocity;
    // Start is called before the first frame update

    [SerializeField]
    float acceleration = 5f;

    [SerializeField]
    float angle = 0.7f;

    Boolean move_left = true;
    Boolean move_right = false;

    void Start()
    {
        Debug.Log("Object Swings");
        //default case//
        if (rotation_velocity == new Vector3(0, 0, 0))
            rotation_velocity = new Vector3(0, 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (move_left)
            MoveLeft();
        if (move_right)
            MoveRight();

    }

    //this method moves the pendulum to the right up to 80
    void MoveRight()
    {
        Debug.Log("Pendulum moves right, z = " + (transform.eulerAngles.z) + " TOP: " + angle);
        transform.eulerAngles += rotation_velocity * Time.deltaTime / acceleration;
        if ((transform.rotation.z) >= angle) // where z > 80 move it left -> now its time to move left again.
        {
            // Debug.Log("Pendulum shifts to moves left");
            move_left = true;
            move_right = false;
        }
    }

    //this method moves the pendulum to the left up to -80
    void MoveLeft()
    {
        Debug.Log("Pendulum moves left, z = " + (transform.eulerAngles.z) + " TOP: " + angle);
        transform.eulerAngles += -1 * rotation_velocity * Time.deltaTime / acceleration;
        if ((transform.rotation.z) >= angle) // where z > 280 now move right -> now its time to move right again.
        {
            // Debug.Log("Pendulum shifts to move right");
            move_left = false;
            move_right = true;
        }
    }
}
