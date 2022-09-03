using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private Drop _drop;
    [SerializeField] private OffsetSpawnStyle _style;

    public void Drop()
    {
        foreach (DropItem dropItem in _drop.DropItems)
            for (int i = 0; i < dropItem.Amount; i++)
            {
                Vector2 spawnPoint = _style.CalculatePoint();

                GameObject obj = Instantiate(dropItem.Item.gameObject, spawnPoint + 
                    (Vector2)transform.position, Quaternion.identity);
                obj.layer = LayerMask.NameToLayer("Drop");
            }
    }
}
