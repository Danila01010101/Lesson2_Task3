using System;
using UnityEngine;

[Serializable]
public class RunningSpeedUpConfig
{
    [SerializeField, Range(0, 50)] private float _speed;
    
    public float Speed => _speed;
}