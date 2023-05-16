using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed;
    [SerializeField] private Rigidbody2D m_Rb;

    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        m_Rb.MovePosition(m_Rb.position + movement * m_MoveSpeed * Time.fixedDeltaTime);
    }
}