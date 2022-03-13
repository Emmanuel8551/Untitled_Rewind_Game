using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolItem
{
    public GameManager.MainScript GameManager { get; set; }
}
