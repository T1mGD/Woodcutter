using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCellView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _frame;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private InventoryCellView _defaultCell;
    [SerializeField] private InventoryCellView _selectedCell;    

    public void RenderUpdate(InventoryCell cell)
    {
        if (cell.IsEmpty)
        {
            SetDefault();           
        }
        else
        {
            _text.text = cell.Data.Name + " x" + cell.ItemAmount;
            SetIcon(cell.Data.Icon);
        }
    }

    public void SetDefault()
    {
        _text.text = _defaultCell._text.text;
        _icon.rectTransform.localScale = _defaultCell._icon.rectTransform.localScale;
        _icon.sprite = _defaultCell._icon.sprite;
    }
    
    public void Select()
    {
        _frame.color = _selectedCell._frame.color;
    }

    public void Deselect()
    {
        _frame.color = _defaultCell._frame.color;
    }  

    private void SetIcon(Sprite newIcon)
    {
        _icon.transform.localScale = newIcon.rect.size /
            Mathf.Max(newIcon.rect.size.x, newIcon.rect.size.y);
        _icon.sprite = newIcon;
    }
}
