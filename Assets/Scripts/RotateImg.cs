using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImg : MonoBehaviour
{
    public float rotationImg = 5f;

    
    void Update()
    {
       Transform imgTransform = GetComponent<Transform>();
       imgTransform.Rotate(0f, 0f, rotationImg * Time.deltaTime );
    }
}
