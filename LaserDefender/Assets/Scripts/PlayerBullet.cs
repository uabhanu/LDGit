using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;

    Rigidbody2D m_bulletBody2D;

    void Start()
    {
        m_bulletBody2D = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        m_bulletBody2D.velocity = new Vector2(0f , m_moveSpeed);

        float zDistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 topMostPos = Camera.main.ViewportToWorldPoint(new Vector3(0f , 1f , zDistance));

        if(transform.position.y >= topMostPos.y)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        PlayerController.m_bulletsCount--;    
    }
}
