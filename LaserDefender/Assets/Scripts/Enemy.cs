using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	void Start()
    {
		
	}
	
	void Update()
    {
		
	}

    void OnTriggerEnter2D(Collider2D tri2D)
    {
        if(tri2D.gameObject.tag.Equals("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
