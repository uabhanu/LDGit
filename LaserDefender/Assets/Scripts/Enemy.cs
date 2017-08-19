using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float m_bulletSpawnOffset , m_fireInterval01 , m_fireInterval02;

    [SerializeField] GameObject m_bulletPrefab;

    [SerializeField] int m_scoreValue;

    Animator m_arriveAnim;
    ScoreManager m_scoreManager;

	void Start()
    {
        m_arriveAnim = GetComponent<Animator>();
        m_arriveAnim.SetBool("Idle" , true);
        m_scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine("FireBulletsRoutine");
	}
	
    IEnumerator FireBulletsRoutine()
    {
        yield return new WaitForSeconds(Random.Range(m_fireInterval01 , m_fireInterval02));
        FireBullet();
        StartCoroutine("FireBulletsRoutine");
    }

    void FireBullet()
    {
        Instantiate(m_bulletPrefab , new Vector3(transform.position.x , transform.position.y - m_bulletSpawnOffset) , Quaternion.Euler(0f , 0f , 180f));
    }

    void OnTriggerEnter2D(Collider2D tri2D)
    {
        if(tri2D.gameObject.tag.Equals("PlayerBullet"))
        {
            m_scoreManager.Score(m_scoreValue);
            Destroy(gameObject);
        }
    }
}
