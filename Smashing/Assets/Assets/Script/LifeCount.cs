﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public static float Lives = 3;
    public Text countText;
	
	// Update is called once per frame
    void Update ()
    {
        countText.text = "Lives: " + Lives;
    }
}
