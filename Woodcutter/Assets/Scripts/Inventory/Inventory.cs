using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event Action<Item> OnSelectedItemChanged;

    public List<InventoryCell> Cells { get; }
    private InventoryContainer _container;
    private InventoryCell _selectedCell;
    private InventoryDropper _dropper;

    public Inventory(List<InventoryCell> cells, InventoryDropper dropper, InventoryContainer container)
    {
        Cells = cells;
        _container = container;
        _dropper = dropper;
    }

    public void Add(Item item)
    {
        _container.Add(item);

        if (!TryMerge(item.Data))
            if (!TryAdd(item.Data))
                _dropper.Drop(_container.GetRemove(item));

        OnSelectedItemChanged?.Invoke(GetSelectedItem());
    }

    public void DropSelectedItem()
    {
        if (_selectedCell.IsEmpty)
            return;

        var item = GetSelectedItem();
        _container.Remove(item);
        _selectedCell.RemoveItem();
        OnSelectedItemChanged?.Invoke(GetSelectedItem());
        _dropper.Drop(item);
    }

    public void SelectCell(int index)
    {
        _selectedCell?.Deselect();
        _selectedCell = Cells[Mathf.Clamp(index, 0, Cells.Count - 1)];
        _selectedCell.Select();

        OnSelectedItemChanged?.Invoke(GetSelectedItem());
    }    

    private bool TryAdd(ItemData data)
    {
        InventoryCell cell = GetFreeCell();
        if (cell)
            cell.Set(data);

        return cell != null;
    }

    private InventoryCell GetFreeCell()
    {
        foreach (InventoryCell cell in Cells)
            if (cell.IsEmpty)
                return cell;
        return null;
    }

    private bool TryMerge(ItemData data)
    {
        InventoryCell cell = GetMergeableCell(data);
        if (cell)
            cell.AddItem();
        return cell != null;
    }

    private InventoryCell GetMergeableCell(ItemData data)
    {
        foreach (InventoryCell cell in Cells)
            if (!cell.IsEmpty && !cell.IsFull && cell.Data.ID == data.ID)
                return cell;
        return null;
    }  

    private Item GetSelectedItem()
    {
        if (_selectedCell.IsEmpty)
            return null;
        else 
            return _container.GetItem(_selectedCell.Data);
    }
}
