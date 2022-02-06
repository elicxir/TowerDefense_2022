using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class GameManager : GameManager_Base
{
    //static�ϐ�Game_Manager�̌^�ύX
    new public static GameManager Game_Manager
    {
        get
        {
            return (GameManager)GameManager_Base.Game_Manager;
        }
    }

    protected override void GAME_AWAKE()
    {
        StateQueue(gamestate.Scene);
    }

}