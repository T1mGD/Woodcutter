using UnityEngine;

public class InventoryDropper : MonoBehaviour
{
    [SerializeField] private OffsetSpawnStyle _calculator;

    public void Drop(Item item)
    {
        item.gameObject.SetActive(true);
        item.transform.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
        item.transform.position = (Vector2)transform.position + _calculator.CalculatePoint();
        item.gameObject.layer = LayerMask.NameToLayer("Drop");
    }
}
