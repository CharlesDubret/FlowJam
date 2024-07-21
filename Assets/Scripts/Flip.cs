using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flip : Activity
{
	public bool Left;
	public Quaternion from;
	public Quaternion to;
	public Transform target;
	
	public float speed;
	private float timeCount;

	private int _count = 0;
	[SerializeField] private int FlipAfter;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Box"))
		{
			print("box");
			_count++;
			if (_count >= FlipAfter)
			{
				ProcessFlip();
				_count = 0;
			}
		}
	}

	private void ProcessFlip()
	{
		print("processflip");
		Left = !Left;
		timeCount = 0;
	}

	public void Update()
	{
		if (Left)
		{
			target.rotation = Quaternion.Lerp(from, to, timeCount * speed);
			timeCount += Time.deltaTime;
		}

		if (!Left)
		{
			target.rotation = Quaternion.Lerp(to, from, timeCount * speed);
			timeCount += Time.deltaTime;
		}
	}

	public void SetFlipAfter(int value)
	{
		FlipAfter = value;
	}
}