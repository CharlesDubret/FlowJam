using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : Activity
{
	public ParticleSystem Dust;
	bool isColliding;

	public List<Color> selectedColorOrder;

	private int _paintNumber = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Box"))
		{
			if (isColliding) return;
			isColliding = true;
			PaintBox(other);
			Dust.Play();
		}
	}

	private void PaintBox(Collider other)
	{
		Color newColor = selectedColorOrder[_paintNumber % selectedColorOrder.Count];
		other.GetComponent<MeshRenderer>().material.color = newColor;
		_paintNumber++;
	}

	public void SetSelectedColorsOrder(List<Color> order)
	{
		selectedColorOrder.Clear();
		foreach (Color color in order)
		{
			selectedColorOrder.Add(color);
		}
	}

	void Update()
	{
		isColliding = false;
	}
}