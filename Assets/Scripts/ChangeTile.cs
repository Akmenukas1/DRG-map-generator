using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTile : MonoBehaviour
{
    [SerializeField] private Tilemap Tilemap;
    [SerializeField] private TileBase newTile;
    [SerializeField] private TileBase oldTile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos.z);
            mousePos.z = 0;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3Int cellPosition = Tilemap.WorldToCell(mouseWorldPos);
            cellPosition.z = 0;

            TileBase currentTile = Tilemap.GetTile(cellPosition);

            Debug.Log(Tilemap.HasTile(cellPosition));
            Debug.Log(cellPosition);


            if(currentTile == oldTile)
            {
                Tilemap.SetTile(cellPosition, newTile);
            }
            else
            {
                Tilemap.SetTile(cellPosition, oldTile);
            }
            

            
        }
        
        
    }
}