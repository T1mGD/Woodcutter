using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _ID;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _stackÑapacity = 1;

    public int ID => _ID;
    public string Name => _name;
    public Sprite Icon => _sprite;
    public int StackSize => _stackÑapacity;

    public override bool Equals(object other)
    {
        if (!(other is ItemData))        
            return false;
        
        return ID == ((ItemData)other).ID;
    }
    public override int GetHashCode() => ID;
}
