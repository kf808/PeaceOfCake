using UnityEngine;
using UnityEngine.UI;

public class BossDisplay : MonoBehaviour
{
    [SerializeField]
    private Slider bossHealthSlider;
    [SerializeField]
    private EnemyTower bossHealth;

    private void Start()
    {
        bossHealthSlider.maxValue = 500f;
    }

    private void Update()
    {
        bossHealthSlider.value = bossHealth.Health;
    }
}
