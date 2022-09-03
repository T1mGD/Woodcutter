using UnityEngine;

public abstract class Item : MonoBehaviour 
{
    [SerializeField] private ItemData _data;
    public ItemData Data => _data;

    private void Start()
    {
        if (_data == null)
            throw new UnityException(name + " Data is not set!");
    }
}