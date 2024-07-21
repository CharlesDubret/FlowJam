using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRange : MonoBehaviour
{
	[SerializeField] private ActivitySetup activitySetup;
	[SerializeField] private Activity activity;

	private Collider col;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			col = other;
	}

	private void OnTriggerExit(Collider other)
	{
		col = null;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.F) && col != null)
		{
			activitySetup.Initialize(activity);
		}
	}
}
