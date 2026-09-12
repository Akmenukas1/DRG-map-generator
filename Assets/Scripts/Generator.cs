using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public GameObject hexPrefab;
    public Slider scaleSlider;

    public int width = 10;
    public int height = 10;

    void Start()
    {
        scaleSlider.onValueChanged.AddListener(UpdateScale);
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float size = scaleSlider.value;

                float hexWidth = Mathf.Sqrt(3f) * size;
                float hexHeight = 2f * size;

                float posX = x * hexWidth;
                float posZ = y * (hexHeight * 0.75f);

                // Offset every other column
                if (x % 2 == 1)
                    posZ += hexHeight * 0.375f;

                GameObject hex = Instantiate(
                    hexPrefab,
                    new Vector3(posX, 0, posZ),
                    Quaternion.identity,
                    transform
                );

                hex.transform.localScale = Vector3.one * size;
            }
        }
    }

    void UpdateScale(float value)
    {
        transform.localScale = Vector3.one * value;
    }
}
