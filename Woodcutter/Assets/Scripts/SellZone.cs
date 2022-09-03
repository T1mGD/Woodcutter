using System;
using UnityEngine;

public class SellZone : MonoBehaviour
{
    [SerializeField] private CoinBank _coinBank;
    [SerializeField] private SellableItem[] _sellableItems;

    [Serializable] 
    private class SellableItem
    {
        [SerializeField] private ItemData _data;
        [SerializeField] private int _price;

        public ItemData Data => _data;
        public int Price => _price;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Drop"))
        {
            if (collision.TryGetComponent(out Item item))
                foreach (var sellableItem in _sellableItems)
                    if (sellableItem.Data.ID == item.Data.ID)
                    {
                        _coinBank.Add(sellableItem.Price);
                        Destroy(collision.gameObject);
                    }
        }
    }
}
