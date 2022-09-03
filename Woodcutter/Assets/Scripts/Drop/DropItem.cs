using System;
using UnityEngine;

[Serializable]
public class DropItem 
{
    [SerializeField] private Item _item;
    [SerializeField] private int _amount;
    public Item Item => _item;
    public int Amount => _amount;

    public DropItem(Item item, int amount = 1)
    {
        _item = item;
        _amount = amount;
    }
}
