using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField]
    private float weight = 50f;
    [SerializeField]
    private float minWeight = 50f;
    [SerializeField]
    private bool noWeight;

    private void Update()
    {
        if (noWeight)
            weight = minWeight;
    }

    public void IncreaseWeight(float amount)
    {
        weight = weight + amount;
    }

    public void LoseWeight(float amount)
    {
        weight = weight - amount;

        if (weight < minWeight)
            weight = minWeight;

    }

    public float GetWeight()
    {
        return weight;
    }

    public float GetMinWeight()
    {
        return minWeight;
    }
}
