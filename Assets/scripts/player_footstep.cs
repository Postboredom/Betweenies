using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_footstep : MonoBehaviour {
    CharacterController controller;
    AudioSource clip;
    float steptime;
    float nextstep;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        clip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        var magnitude = controller.velocity.sqrMagnitude;
        if(magnitude<0)
        {
            return;
        }
        else
        {
            steptime += controller.velocity.magnitude * Time.fixedDeltaTime;
        }
        if(steptime<= nextstep)
        {
            return;
        }
        nextstep = steptime + .65f;
        clip.Play();
	}
}
