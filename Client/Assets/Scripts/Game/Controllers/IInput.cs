using UnityEngine;

public interface IInput
{
    public bool CanMove { get; set; }
    public Vector3 CurrentInput { get; }
} 