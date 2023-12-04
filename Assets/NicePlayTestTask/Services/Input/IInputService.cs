using System;
using UnityEngine;

namespace NicePlayTestTask.Services.Input
{
    public interface IInputService
    {
        Action<Vector2> PointerPositionChanged { get; set; }
        
        Action Drag { get; set; }
        Action Drop { get; set; }
    }
}