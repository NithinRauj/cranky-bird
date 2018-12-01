﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

private CircleCollider2D bodyCollider;
private Rigidbody2D rb;
private Animator anim;
public float vertVelocity=2f;
public static bool isDead=false;
void Start()
{
  rb=GetComponent<Rigidbody2D>();
  anim=GetComponent<Animator>();
}
void Update()
{
    //To make sure the bird cant flap once it collides with columns
    if(!isDead)
    {
        //For playtesting with mouse 
        if(Input.GetMouseButtonDown(0))                 
        {
        rb.velocity=new Vector2(rb.velocity.x,vertVelocity);
        anim.SetBool("isFlapping",true);
        }
        else{
        anim.SetBool("isFlapping",false);
        }

        if(Input.touchCount>0)
        {
        rb.velocity=new Vector2(rb.velocity.x,vertVelocity);
        }
    }

    else
    {
        return;
    }
    
}

public void KillBird()
{ 
    if(!isDead)
    {
     isDead=true;
     GameControl.instance.DisplayFinalScore();
    anim.SetTrigger("isDead");
    Destroy(gameObject,4f);
    }

    else
    {
        return;
    }
}

//Defines what to do once the bird collides with columns
void OnCollisionEnter2D(Collision2D other)
{
   KillBird();
}
void OnTriggerExit2D(Collider2D collider)
{
   if(!collider.GetComponent<ScoreTrigger>())
   {KillBird();}
}
}
