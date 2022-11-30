using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private Slider weightSlider;
    [SerializeField]
    private Weight playerWeight;

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetMaxHealth();
        weightSlider.minValue = playerWeight.GetMinWeight();
        weightSlider.maxValue = 300f;
    }

    private void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        weightSlider.value = playerWeight.GetWeight();
    }
}
