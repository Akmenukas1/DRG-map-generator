using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Globalization;

public class TilemapScaler : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text scaleText;

    private string savePath;

    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "tilemap_scale.txt");

        // Load saved value
        float savedScale = LoadScale();

        slider.value = savedScale;
        SetScale(savedScale);

        // Listen for slider changes
        slider.onValueChanged.AddListener(SetScale);
    }

    private void SetScale(float value)
    {
        // Scale Tilemap
        transform.localScale = Vector3.one * value;

        // Show exact number
        scaleText.text = value.ToString("0.00", CultureInfo.InvariantCulture);

        // Save to TXT
        SaveScale(value);
    }

    private void SaveScale(float value)
    {
        File.WriteAllText(
            savePath,
            value.ToString(CultureInfo.InvariantCulture)
        );
    }

    private float LoadScale()
    {
        if (File.Exists(savePath))
        {
            string text = File.ReadAllText(savePath);

            if (float.TryParse(
                text,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out float value))
            {
                return value;
            }
        }

        // Default value
        return 1f;
    }
}