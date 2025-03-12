using System.Collections;
using UnityEngine;

public class HealthBarSliderSmooth : BaseSliders
{
    [Range(5, 10)] [SerializeField] private int _speedChangingHeath;

    protected override void OnHealthChanged()
    {
        StartCoroutine(ChangeSliderSmooth());
    }

    private IEnumerator ChangeSliderSmooth()
    {
        while (!Mathf.Approximately(Slider.value, Health.CurrentPoints))
        {
            Slider.value =
                Mathf.MoveTowards(Slider.value, Health.CurrentPoints, Time.deltaTime * _speedChangingHeath);

            yield return null;
        }
    }
}