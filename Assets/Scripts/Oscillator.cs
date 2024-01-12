using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Oscillator : MonoBehaviour
{
    [SerializeField]
    Vector3 rotation_velocity;
    // Start is called before the first frame update

    [SerializeField]
    float angle = 0.7f;

    [SerializeField]
    float acceleration;

    float _acc;

    Boolean move_left = true;
    Boolean move_right = false;

    void Start()
    {
        Debug.Log("Object Swings");
        //default case//
        if (rotation_velocity == new Vector3(0, 0, 0))
            rotation_velocity = new Vector3(0, 0, 30);
        
        _acc = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        Acceleration();

        if (move_left)
            MoveLeft();
        if (move_right)
            MoveRight();

    }

    //his method moves the pendulum to the right up to the chosen angle
    void MoveRight()
    {
        Debug.Log("Pendulum moves right, z = " + (transform.rotation.z) + " TOP: " + angle);
        transform.eulerAngles += rotation_velocity * Time.deltaTime;
        // rotation_velocity.z += 2f;
        if ((transform.rotation.z) >= angle) // peak angle side -> now its time to move left again.
        {
            rotation_velocity.z += _acc;
            // Debug.Log("Pendulum shifts to moves left");
            move_left = true;
            move_right = false;
        }
    }

    //this method moves the pendulum to the left up to the chosen angle
    void MoveLeft()
    {
        Debug.Log("Pendulum moves left, z = " + (transform.rotation.z) + " TOP: " + angle);
        transform.eulerAngles += -1 * rotation_velocity * Time.deltaTime;
        // rotation_velocity.z += 2f;
        if ((transform.rotation.z) >= angle) // peak angle side -> now its time to move right again.
        {
            rotation_velocity.z += _acc; 
            // Debug.Log("Pendulum shifts to move right");
            move_left = false;
            move_right = true;
        }

    }

    //This method is suppose to handle accelaration and deaccalaration of the object
    void Acceleration()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < 0.30)
            rotation_velocity.z = acceleration;
    }
}
