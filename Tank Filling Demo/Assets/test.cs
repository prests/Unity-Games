using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    private int num1;
    public int num2;
    public GameObject cube1;
	// Use this for initialization
	void Start () {
        cube1.transform.localScale = new Vector3(cube1.GetComponent<Renderer>().bounds.size.x+5, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        cube1.transform.localScale = new Vector3(1, cube1.GetComponent<Renderer>().bounds.size.y + 1, 1);
	}
}
