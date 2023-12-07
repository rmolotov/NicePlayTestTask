using System;
using UnityEngine;

namespace NicePlayTestTask.Services.Input
{
    public interface IInputService
    {
        Action<Vector2> PointerPositionChanged { get; set; }
        
        Action Drag { get; set; }
        Action Drop { get; set; }
        
        Action ReloadScene { get; set; }
        Action LoadSave { get; set; }
        Action ShowCombinations { get; set; }
    }
}