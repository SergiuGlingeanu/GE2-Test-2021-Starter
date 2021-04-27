using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWagging : MonoBehaviour
{
    public float speed, coverage;
    private float _currentAngle;
    private bool _goingUp = true;
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, _currentAngle, 0);
        if (_goingUp) _currentAngle += speed * Time.deltaTime;
        else _currentAngle -= speed * Time.deltaTime;

        if (_currentAngle >= coverage && _goingUp) _goingUp = false;
        if (_currentAngle <= -coverage && !_goingUp) _goingUp = true;
    }
}
