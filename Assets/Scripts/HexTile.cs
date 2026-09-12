using UnityEngine;
using UnityEngine.Tilemaps;

public class HexTile : MonoBehaviour
{
    public Tilemap tilemap;
    public float scale = 0.9f;

    void Start()
    {
        if (tilemap == null)
            tilemap = GetComponent<Tilemap>();

        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position))
            {
                tilemap.SetTransformMatrix(
                    position,
                    Matrix4x4.TRS(
                        Vector3.zero,
                        Quaternion.identity,
                        Vector3.one * scale
                    )
                );
            }
        }
    }
}
