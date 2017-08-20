using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_bulletSpawnOffset , m_moveSpeed , m_offset;

    [SerializeField] GameObject m_bulletPrefab;

    [SerializeField] int m_enemiesToBeDestroyed , m_maxBullets;

    public static int m_bulletsCount;

    float m_xMax , m_xMin;
    LevelManager m_levelManager;

    void Reset()
    {
        m_bulletSpawnOffset = 0.75f;
        m_maxBullets = 1;    
        m_moveSpeed = 10f;
        m_offset = 0.5f;
    }

    void Start()
    {
        Enemy.m_enemiesDestroyed = 0;
        float zDistance = transform.position.z - Camera.main.transform.position.z;
        m_levelManager = FindObjectOfType<LevelManager>();
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(m_bulletsCount < m_maxBullets)
            {
                Instantiate(m_bulletPrefab , new Vector3(transform.position.x , transform.position.y + m_bulletSpawnOffset) , Quaternion.identity);
                m_bulletsCount++;
            }
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

        if(Enemy.m_enemiesDestroyed == m_enemiesToBeDestroyed)
        {
            m_levelManager.LoadScene("Win");
        }
	}

    void OnTriggerEnter2D(Collider2D tri2D)
    {
        if(tri2D.gameObject.tag.Equals("EnemyBullet"))
        {
            m_levelManager.LoadScene("Lose");
            Destroy(gameObject);
        }
    }
}
