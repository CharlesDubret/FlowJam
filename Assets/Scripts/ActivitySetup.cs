using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActivitySetup : MonoBehaviour
{
	public bool IsReady;

	public UnityEvent SendReady;

	public abstract void Initialize(Activity activity);
}
