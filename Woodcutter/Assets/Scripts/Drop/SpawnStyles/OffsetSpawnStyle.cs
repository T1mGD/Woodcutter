using UnityEngine;

[CreateAssetMenu(menuName = "SpawnStyles/Offset")]
public class OffsetSpawnStyle : ScriptableObject
{
    [SerializeField] private protected Vector2 _offset;

    public virtual Vector2 CalculatePoint() => _offset; 
}
