using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private string playerName;
    private static Player instance = null;

    public Player()
    {
        playerName = "Player";
    }
    

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public static string getName()
    {
        return instance.playerName;
    }

    public static void setName(string p)
    {
        instance.playerName = p;
    }
}

