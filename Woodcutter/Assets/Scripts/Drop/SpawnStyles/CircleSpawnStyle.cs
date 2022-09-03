using UnityEngine;

[CreateAssetMenu(menuName = "SpawnStyles/Circle")]
public class CircleSpawnStyle : OffsetSpawnStyle
{
    [SerializeField] float _radius = 1;

    public override Vector2 CalculatePoint()
    {
        float x, y, maxY;

        x = Random.Range(-_radius, _radius);
        maxY = Mathf.Sqrt((_radius * _radius) - (x * x));
        y = Random.Range(-maxY, maxY);

        return new Vector2(x, y) + _offset;
    }
}
