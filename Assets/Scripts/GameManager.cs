using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private List<Spawner> spawners;
	[SerializeField] private List<ActivitySetup> activitySetups;
	[SerializeField] private List<GameObject> setupCanvases;
	[SerializeField] private int arrivalCount;
	[SerializeField] private int arrivalFinishedCount;
	
	public void CheckGameReady()
	{
		foreach (ActivitySetup setup in activitySetups)
			if (!setup.IsReady)
				return;

		foreach (GameObject obj in setupCanvases)
		{
			List<BoxCollider> colliders = obj.transform.parent.GetComponentsInChildren<BoxCollider>().ToList();
			colliders.RemoveAt(0);
			colliders[0].gameObject.SetActive(false);
			obj.gameObject.SetActive(false);
		}

		foreach (Spawner spawner in spawners)
			spawner.StartPlaying();
	}

	public void addFinishedArrival()
	{
		arrivalFinishedCount++;
		if (arrivalFinishedCount == arrivalCount)
		{
			EndGame();
		}
	}
	
	public void EndGame()
	{
		SceneManager.LoadScene("Main");
	}
	
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("Main");
		}
	}
}