using System.Collections.Generic;
using UnityEngine;
public class InventoryContainer 
{
    public List<Item> _items = new List<Item>();

    public void Add(Item item)
    {
        item.gameObject.layer = LayerMask.NameToLayer("Default");
        item.gameObject.SetActive(false);
        _items.Add(item);
    } 

    public void Remove(Item item) 
    {
        item.gameObject.SetActive(true);
        _items.Remove(item);
    }

    public Item GetItem(ItemData data)
    {
        foreach(Item item in _items)
            if (item.Data.ID == data.ID)
                return item;

        throw new UnityEngine.UnityException("Container has no Item with Data: " + data);
    }

    public Item GetRemove(Item item)
    {
        Remove(item);
        return item;
    }
}
