<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
>>>>>>> e7464b151bcb3b717d7f8649be3df52b97ea4317
