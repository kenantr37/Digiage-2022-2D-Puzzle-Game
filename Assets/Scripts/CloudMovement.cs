using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] float freq, magn, offset;
    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.position = startPosition + transform.right * Mathf.Sin(Time.time * freq + offset) * magn;
    }
}
