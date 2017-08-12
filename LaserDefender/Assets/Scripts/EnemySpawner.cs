using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject m_enemyPrefab;

	void Start()
    {
	    GameObject enemyObj = Instantiate(m_enemyPrefab , transform.position , Quaternion.identity) as GameObject;	
        enemyObj.transform.parent = transform;
	}
	
	void Update()
    {
		
	}
}
