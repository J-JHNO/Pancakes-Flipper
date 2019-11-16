using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace player
{
    public class Player : MonoBehaviour
    {
        private string playerName;
        private static Player instance = null;

        private Player(string pseudo)
        {
            playerName = pseudo;
        }

        public static Player build(string pseudo)
        {
            if (instance == null)
            {
                instance = new Player(pseudo);
            }
            return instance;
        }

        public static Player getInstance()
        {
            return instance;
        }

        public static string getName()
        {
            return instance.playerName;
        }
    }
}
