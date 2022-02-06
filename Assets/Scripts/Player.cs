using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int speed;

    // Update is called once per frame
    public void Updater()
    {
        this.transform.position+=(Vector3)GameManager.Game_Manager.Input.InputArrow() * speed* Time.deltaTime;
    }
}
