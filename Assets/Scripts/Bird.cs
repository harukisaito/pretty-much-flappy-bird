using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float UpForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rigidbody2D;
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDead == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(new Vector2(0, UpForce));
				animator.SetTrigger("Flap");
			}
		}	
	}

	void OnCollisionEnter2D()
	{
		rigidbody2D.velocity = Vector2.zero;
		isDead = true;
		animator.SetTrigger("Die");
		GameControl.instance.BirdDied();
	}
}
