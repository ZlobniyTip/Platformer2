using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Slider.value = 1;
        Text.text = _player.MaxHealth.ToString() + ($"/ " + _player.MaxHealth);
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}