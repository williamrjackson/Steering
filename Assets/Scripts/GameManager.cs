using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public Text scoreOutput;

	private int score;
	private bool isGameOver;

	public Action OnGameOver;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			// Bail if an instance already exists
			DestroyObject(this);
		}
	}
	private void Start()
	{
		isGameOver = false;
		score = 0;
		StartCoroutine (RunMeterCounter ());
	}

	public void SetGameOver()
	{
		isGameOver = true;
	}
	public bool GetGameOver()
	{
		return isGameOver;
	}

	private IEnumerator RunMeterCounter()
	{
		while (!isGameOver) {
			yield return new WaitForSeconds(.5f);
			score += 1;
			scoreOutput.text = score.ToString() + " m";

		}
	}

}
