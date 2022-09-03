using UnityEngine;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private InventoryCellView _view;
    public ItemData Data { get; private set; }
    public int ItemAmount { get; private set; }
    public bool IsEmpty => ItemAmount == 0;
    public bool IsFull => ItemAmount == Data?.StackSize;

    public void Set(ItemData data)
    {
        if (Data)
            throw new System.InvalidOperationException($"Cell already contains Item");
        Data = data;
        ItemAmount = 1;

        _view.RenderUpdate(this);
    }

    public void AddItem()
    {
        if (IsFull)
            throw new System.InvalidOperationException($"Cell is full");
        else
            ItemAmount++;

        _view.RenderUpdate(this);
    }

    public void RemoveItem()
    {
        if (IsEmpty)
            throw new System.InvalidOperationException($"Cell is empty");
        else
            ItemAmount--;        

        if (ItemAmount == 0)
            Data = null;

        _view.RenderUpdate(this);
    }

    public void Select() => _view.Select();

    public void Deselect() => _view.Deselect();
}