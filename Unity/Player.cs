using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement Movement { get; private set; }
    public Keys Keys;
    public PlayerStats Stats;
    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
    }
}
