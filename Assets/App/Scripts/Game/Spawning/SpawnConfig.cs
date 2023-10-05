using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SpawnConfig", fileName = "Spawn Options")]
public class SpawnConfig : ScriptableObject
{
    public SpawnSide[] sides;
    
    [Range(0, 1)] public float offsetPercent;
    
    [Min(0)] public int minBlockCount;
    
    [Min(0)] public int maxBlockCount;
}

[Serializable]
public class SpawnSide
{
    public SideType type;
    
    public SpawnField[] fields;
    
    [Range(0, 1)] public float spawnChance;
}

public enum SideType
{
    Left,
    Bottom,
    Right,
}
