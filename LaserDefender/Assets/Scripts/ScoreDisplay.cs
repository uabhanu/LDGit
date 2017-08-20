using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	void Start()
    {
		Text scoreDisplay = GetComponent<Text>();
        scoreDisplay.text = ScoreManager.m_score.ToString();
        ScoreManager.Reset();
	}
}
