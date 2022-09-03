using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(InventoryDropper))]

public class InventoryController : MonoBehaviour
{
    [SerializeField] private List<InventoryCell> _inventoryCells;
    [SerializeField] private int _visibilityRange;

    private InventoryContainer _container;
    private InventoryDropper _dropper;
    private Inventory _inventory;

    private Player _player;

    private void Awake()
    {
        _container = new();
        _dropper = GetComponent<InventoryDropper>();
        _inventory = new Inventory(_inventoryCells, _dropper, _container);

        _player = GetComponent<Player>();
    }

    private void Start() =>              
        _inventory.SelectCell(0);

    private void OnEnable() =>
        _inventory.OnSelectedItemChanged += _player.SetHoldingItem;

    private void OnDisable() =>
        _inventory.OnSelectedItemChanged -= _player.SetHoldingItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            if (TryGetCollision(out List<Item> items))
                _inventory.Add(GetClosestOf(items));

        if (Input.GetKeyDown(KeyCode.Q))
            _inventory.DropSelectedItem();

        for (int i = 0; i < 9; i++)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                _inventory.SelectCell(i);
    }

    private Item GetClosestOf(List<Item> items)
    {
        Item closest = items[0];
        float closestDistance = Vector2.Distance(closest.transform.position,
            transform.position);

        foreach (var item in items)
        {
            float distance = Vector2.Distance(item.transform.position, 
                transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = item;
            }
        }
        return closest;
    }

    private bool TryGetCollision(out List<Item> items)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position,
            _visibilityRange, LayerMask.GetMask("Drop"));
        items = new List<Item>();

        foreach (Collider2D collision in collisions)        
            if (collision.TryGetComponent(out Item item))
                items.Add(item);
        return items.Count > 0;
    }
}
