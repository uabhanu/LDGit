using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject m_enemyPrefab;

	void Start()
    {
        foreach(Transform child in transform)
        {
            GameObject enemyObj = Instantiate(m_enemyPrefab , child.transform.position , Quaternion.identity) as GameObject;	
            enemyObj.transform.parent = child;
        }
	}
	
	void Update()
    {
		
	}
}
