using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {

	public Light sun;

	const float DAY = 2 * Mathf.PI;

	bool night = false;

	public float secondsInFullDay = 50f;

	[Range(0, 2 * Mathf.PI)]
	public float currentTimeOfDay = 0;

	float timeMultiplier = 100f;

	public Color color;

	float sunInitialIntensity;

	void Start() {
		sunInitialIntensity = sun.intensity;
	}

	void Update() {
		currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

		sun.transform.localRotation = Quaternion.Euler (currentTimeOfDay / DAY * 180f, 150f, 0);
		sun.intensity = Mathf.Sin (currentTimeOfDay - Mathf.PI / 2);

		if (!night) {
			color = new Color (1f, Mathf.Clamp01 (1f + Mathf.Sin (currentTimeOfDay - Mathf.PI / 2) / 2), Mathf.Clamp01 (1f + Mathf.Sin (currentTimeOfDay - Mathf.PI / 2)));
            color *= .5f;
		}
		else {
			color = new Color (0f, 0.2f, 1f);
		}

		sun.color = Color.Lerp(sun.color, color,Time.deltaTime*timeMultiplier);

		if (currentTimeOfDay >= DAY) {
			currentTimeOfDay = 0;
			night = !night;
		}
	}

	/*
		//update time of day independently from framerate
	currentTimeOfDay += (Time.deltaTime / secondsInFullDay)*timeMultiplier;

	// rotate 180 degrees and jump back
	sun.transform.localRotation = Quaternion.Euler(currentTimeOfDay / DAY * 180f, 150f, 0);

	//modify color during day, but keep the same color during night
	if (!night) {
		color = new Color (1f, Mathf.Clamp01(1f + Mathf.Sin (currentTimeOfDay - Mathf.PI / 2) / 2), Mathf.Clamp01(1f + Mathf.Sin (currentTimeOfDay - Mathf.PI / 2)));
	} else {
		color = new Color (0f, 0.2f, 1f);

	}
	// slowly lerp between colors.
	sun.color = Color.Lerp(sun.color, color,Time.deltaTime*timeMultiplier);

	// RenderSettings.ambientLight = sun.color;

	// minimum intensity is 1 (because min value of Sin is -1, maximum is 3
	sun.intensity = 2f + Mathf.Sin (currentTimeOfDay-Mathf.PI/2);

	// reset time when full period passed
	if (currentTimeOfDay >= DAY) {
		currentTimeOfDay = 0;
		night = !night;
	}*/

}