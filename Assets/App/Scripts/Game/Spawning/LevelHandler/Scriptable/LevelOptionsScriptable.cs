﻿using UnityEngine;

namespace App.Scripts.Game.Spawning.LevelHandler.Scriptable
{
    [CreateAssetMenu(fileName = "Level Options", menuName = "Scriptable Object/Level Config", order = 0)]
    public class LevelOptionsScriptable : ScriptableObject
    {
        [Header("Base Options")] [Min(0)]
        public int targetFrameRate;
        
        public LevelOptions options;

    }
}