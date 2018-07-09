using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pauser : MonoBehaviour
{
    public static void TimeStoper()
    {
        Time.timeScale = 0;
    }

    public static void Restart()
    {
        Time.timeScale = 1;
    }
}