﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{ public SlingShooter SlingShooter;
    public List<Bird> Birds;

    void Start()
    {
        // for(int i = 0; i < Birds.Count; i++)
        // {
        //     Birds[i].OnBirdDestroyed += ChangeBird;
        // }
        SlingShooter.InitiateBird(Birds[0]);
    }
    //  public void ChangeBird()
    // {
    //     Birds.RemoveAt(0);

    //     if(Birds.Count > 0)
    //         SlingShooter.InitiateBird(Birds[0]);
    // }
}
