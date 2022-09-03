using UnityEngine;

[CreateAssetMenu(menuName = "Drop")]
public class Drop : ScriptableObject
{
    [SerializeField] private DropItem[] _dropItems;
    public DropItem[] DropItems => _dropItems;
     
    public void Init(params DropItem[] dropItems) => 
        _dropItems = dropItems;
}
 