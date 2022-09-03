using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{
    [SerializeField] private int _damage; 
    [SerializeField] private Collider2D _hitCollider; 

    override public void Use()
    {
        Hit();
    }

    public void Hit()
    {
        List<Collider2D> collisions = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();

        _hitCollider.OverlapCollider(filter.NoFilter(), collisions);
        foreach(Collider2D collision in collisions)
        {
            if (collision.TryGetComponent(typeof(HealthSystem), out Component component))
            {
                HealthSystem healthSystem = (HealthSystem)component;
                healthSystem.ApplyDamage(_damage);
            }
        }
    }
}
