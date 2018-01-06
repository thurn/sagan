using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeController : MonoBehaviour {

    private Rigidbody _rigidbody;
    private float _speed = 0;

	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            _speed = 3f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _speed = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 60f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * -60f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (ToStandardAngle(transform.eulerAngles.x) < 80)
            {
                transform.RotateAround(transform.position, transform.right, Time.deltaTime * 50f);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (ToStandardAngle(transform.eulerAngles.x) > -80)
            {
                transform.RotateAround(transform.position, transform.right, Time.deltaTime * -50f);
            }
        }
  
        this.transform.position += this.transform.forward * _speed * Time.deltaTime;
    }

    private static float ToStandardAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }
}
