using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public interface IMain<T>
{
    public GameManager.MainScript GameManager { get; set; }
    public ClockManagerScript ClockManagerScript { get; }
    public MovementScript MovementScript { get; }
    public RewindScript<T> RewindScript { get; }
}
