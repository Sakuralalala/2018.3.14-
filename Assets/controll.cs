using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour {
    public Transform playPos;
    private Transform leftPos;
    private Transform rightPos;
    private Transform startPos;
	// Use this for initialization
	void Start () {
        startPos.position = playPos.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
