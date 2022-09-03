using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _handDamage = 1;
    [SerializeField] private Collider2D _handCollider;
    [SerializeField] private Transform _holdingPoint;
    [SerializeField] private Item _holdingItem;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetHoldingItem(_holdingItem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("BaseAttack");
        }        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetHoldingItem(Item item)
    {
        ClearHand();

        if (item != null)
        {
            _holdingItem = item;
            _holdingItem.gameObject.SetActive(true);
            _holdingItem.transform.parent = _holdingPoint;
            _holdingItem.transform.localRotation = Quaternion.identity;
            _holdingItem.transform.localPosition = Vector2.zero;
        }
    }
    
    public void ClearHand()
    {
        if (_holdingItem)
        {
            _holdingItem.transform.parent = null;
            _holdingItem.gameObject.SetActive(false);
            _holdingItem = null;
        }
    }

    private void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical")).normalized;    
        float scaleFactor = 50;
        _rigidbody.MovePosition((Vector2)transform.position + (direction * _speed / scaleFactor)); 

        if (direction.x != 0)
            Rotate(direction);

        _animator.SetBool(Animations.Player.Walking.ToString(), direction != Vector2.zero);
    }

    private void Rotate(Vector2 direction)
    {
        float rotationY = 0;
        if (direction.x < 0)
            rotationY = 180;

        transform.rotation = new Quaternion(0, rotationY, 0, 0);
    }

    public void UseHoldingItem()
    {
        if (_holdingItem is IUseable)
            ((IUseable)_holdingItem).Use();
        else 
            HitWithHand();
    }
    private void HitWithHand()
    {
        var collisions = new List<Collider2D>();
        _handCollider.OverlapCollider(new ContactFilter2D().NoFilter(), collisions);

        foreach(Collider2D collision in collisions)
        {
            if (collision.TryGetComponent(typeof(HealthSystem), out Component component))
            {
                HealthSystem healthSystem = (HealthSystem)component;
                healthSystem.ApplyDamage(_handDamage);
            }
        }
    }
}
