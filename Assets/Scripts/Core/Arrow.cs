﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Touchable
{

    public EventHandler ArrowClicked;
    public EventHandler ArrowHovered;
    public EventHandler ArrowExited;

    private void Start()
    {
        //GetComponent<SpriteRenderer>().color = Color.yellow;
    }


#if (UNITY_STANDALONE)
    private void OnMouseDown()
    {
        if (ArrowClicked != null)
            ArrowClicked.Invoke(gameObject, new EventArgs());
    }

    private void OnMouseOver()
    {
        if(ArrowHovered != null)
            ArrowHovered.Invoke(gameObject, new EventArgs());
    }

    private void OnMouseExit()
    {
        if (ArrowExited != null)
            ArrowExited.Invoke(gameObject, new EventArgs());
    }

#endif
#if (UNITY_IOS || UNITY_ANDROID)
    public void OnTouchDown()
    {
        if (ArrowHovered != null)
            ArrowHovered.Invoke(gameObject, new EventArgs());
        
    }

    public void OnTouchUp()
    {
        if (ArrowClicked != null)
            ArrowClicked.Invoke(gameObject, new EventArgs());
    }

    public void OnTouchExited()
    {
        if (ArrowExited != null)
            ArrowExited.Invoke(this, new EventArgs());
    }
#endif
}
