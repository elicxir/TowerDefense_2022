using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MainGame
{
    [SerializeField]Player player;

    public override void Updater()
    {
        player.Updater();

        GM.Camera.Position= player.transform.position;
    }
}
