using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField]
    Vector3 rotation_axis;

    [SerializeField]
    float rotation_velocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Object rotates on y axis");
        rotation_axis.y = rotation_velocity;
    }

    // Update is called once per frame
    void Update()
    {
         transform.eulerAngles += rotation_axis * Time.deltaTime;
    }
}
