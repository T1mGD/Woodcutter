using UnityEngine;

public abstract class Tool : Item, IUseable
{
    public virtual void Use() { }
}
