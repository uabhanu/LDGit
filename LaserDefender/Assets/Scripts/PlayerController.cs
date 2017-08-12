﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed , m_offset;

    float m_xMax , m_xMin;

    void Start()
    {
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostPos = Camera.main.ViewportToWorldPoint(new Vector3(0f , 0f , zDistance));
        Vector3 rightMostPos = Camera.main.ViewportToWorldPoint(new Vector3(1f , 0f , zDistance));
        m_xMax = rightMostPos.x - m_offset;
        m_xMin = leftMostPos.x + m_offset;
	}
	
	void Update()
    {
		if(Time.timeScale == 0)
        {
            return;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * m_moveSpeed * Time.deltaTime;
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * m_moveSpeed * Time.deltaTime;
        }

        float xRestricted = Mathf.Clamp(transform.position.x , m_xMin , m_xMax);
        transform.position = new Vector3(xRestricted , transform.position.y , transform.position.z);
	}
}