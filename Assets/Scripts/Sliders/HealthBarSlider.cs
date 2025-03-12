public class HealthBarSlider : BaseSliders
{
    protected override void OnHealthChange() => Slider.value = Health.CurrentPoints;
}