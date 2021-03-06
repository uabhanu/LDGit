﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool m_movingRight;
    float m_xMax , m_xMin;

    [SerializeField] float m_height , m_moveSpeed , m_spawnDelay , m_width;

    [SerializeField] GameObject m_enemyPrefab;

	void Start()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0f , 0f , distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1f , 0f , distanceToCamera));
        m_xMax = rightBoundary.x;
        m_xMin = leftBoundary.x;

        SpawnUntilFull();
	}

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        if(m_movingRight)
        {
            transform.position += Vector3.right * m_moveSpeed * Time.deltaTime;
        }  
        else
        {
            transform.position += Vector3.left * m_moveSpeed * Time.deltaTime;
        }

        float leftEdgeOfFormation = transform.position.x - 0.5f * m_width;
        float rightEdgeOfFormation = transform.position.x + 0.5f * m_width;

        if(leftEdgeOfFormation < m_xMin)
        {
            m_movingRight = true;
        }

        else if(rightEdgeOfFormation > m_xMax)
        {
            m_movingRight = false;
        }

        if(AllEnemiesDead())
        {
            SpawnUntilFull();
        }
    }

    bool AllEnemiesDead()
    {
        foreach(Transform childPositionGObj in transform)
        {
            if(childPositionGObj.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    Transform NewVacancy()
    {
        foreach(Transform freePosition in transform)
        {
            if(freePosition.childCount == 0)
            {
                return freePosition;
            }
        }

        return null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position , new Vector3(m_width , m_height));
    }

    void SpawnUntilFull()
    {
        Transform newVacancy = NewVacancy();

        if(newVacancy)
        {
            GameObject enemyObj = Instantiate(m_enemyPrefab , newVacancy.transform.position , Quaternion.identity) as GameObject;	
            enemyObj.transform.parent = newVacancy;
            Invoke("SpawnUntilFull" , m_spawnDelay);
        }
    }
}
