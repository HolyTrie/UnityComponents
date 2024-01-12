using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    [SerializeField]
    float max_scale;

    [SerializeField]
    float min_scale;

    [SerializeField]
    float scale_speed;


    Vector3 _scale_speed;

    Boolean scale_up = true;
    Boolean scale_down = false;
    // Start is called before the first frame update
    void Start()
    {
        _scale_speed = new Vector3(scale_speed, scale_speed, scale_speed);
    }

    // Update is called once per frame
    void Update()
    {
        Scaler();
    }


    // This method checks the scaler to see if its time to scale it up or down
    void Scaler()
    {
        if (transform.localScale.x >= max_scale) //reached top scaling, time to scale down // here it doesnt matter what axis i choose as they all the same, i used x for convience
        {
            scale_down = true;
            scale_up = false;
        }

        if (transform.localScale.x <= min_scale)//reached min scaling, time to scale up again.// here it doesnt matter what axis i choose as they all the same, i used x for convience
        {
            scale_down = false;
            scale_up = true;
        }

        // scale up or down according to size of object
        if (scale_up == true)
            transform.localScale += _scale_speed * Time.deltaTime;
        if (scale_down == true)
            transform.localScale += -1 * Time.deltaTime * _scale_speed;
    }
}
