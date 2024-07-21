using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLerper : MonoBehaviour {

	private Transform startPos;
	public bool repeatable = false;
	public float speed = 1.0f;
	public float duration = 3.0f;
	private bool isLerping = false;
	
	private Vector3 _target;
	
	float startTime, totalDistance;

	public IEnumerator StartLerp (Vector3 target)
	{
		isLerping = true;
		startPos = this.transform;
		_target = target;
		startTime = Time.time;
		totalDistance = Vector3.Distance(startPos.position, _target);
		while(repeatable) {
			yield return RepeatLerp(startPos.position, _target, duration);
			yield return RepeatLerp(_target, startPos.position, duration);
		}
	}
	
	void Update ()
	{
		if (!isLerping) return;
		if (repeatable ) return;
		float currentDuration = (Time.time - startTime) * speed;
		float journeyFraction = currentDuration / totalDistance;
		this.transform.position = Vector3.Lerp(startPos.position, _target, journeyFraction);
	}

	private IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {
		float i = 0.0f;
		float rate = (1.0f / time) * speed;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			this.transform.position = Vector3.Lerp(a, b, i);
			yield return null;
		}
	}
}