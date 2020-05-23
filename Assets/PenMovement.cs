using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class PenMovement : MonoBehaviour
{
    private Rigidbody2D _penBody;
    public float rotationStrength = 5;

    public float maxCharge = 200;
    public float chargeSpeed = 5f;
    private float _charge = 0;
    private GameObject _jumpCollider;

    void Start()
    {
        _penBody = GetComponentInChildren<Rigidbody2D>();
        _jumpCollider = GetComponentInChildren<CircleCollider2D>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        if (_charge < maxCharge && Input.GetButton("Jump"))
        {
            _charge += chargeSpeed;
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            float rotation = (_jumpCollider.transform.eulerAngles.z - 90) * Mathf.Deg2Rad;
            float x = Mathf.Cos(rotation);
            float y = Mathf.Sin(rotation);
            _penBody.AddForce(new Vector2(x, y) * _charge);
            _charge = 0;
        }
        
        _penBody.AddTorque(-movement * rotationStrength);
    }
}
