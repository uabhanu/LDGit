using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int m_score = 0;
    Text m_scoreText;

    public void Reset()
    {
        m_score = 0;    
        m_scoreText.text = m_score.ToString();
    }

    void Start()
    {
        m_scoreText = FindObjectOfType<Text>();   
        m_score = 0;    
        m_scoreText.text = m_score.ToString();
    }

    public void Score(int points)
    {
		m_score += points;
        m_scoreText.text = m_score.ToString();
	}
}
