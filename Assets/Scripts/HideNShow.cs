using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideNShow : MonoBehaviour
{

    [SerializeField]
    InputAction hide = new(type: InputActionType.Button);

    [SerializeField]
    InputAction show = new(type: InputActionType.Button);
    // Start is called before the first frame update

    GameObject obj;
    void Start()
    {
        obj = transform.GetChild(0).gameObject;
    }

    void OnEnable()
    {
        hide.Enable();
        show.Enable();
    }

    void OnDisable()
    {
        hide.Disable();
        show.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (hide.WasPressedThisFrame())
        {
            obj.SetActive(false);
            Debug.Log("Object is hidden now");
        }
        if (show.WasPressedThisFrame())
        {
            obj.SetActive(true);
            Debug.Log("Object is visible now");
        }
    }
}
