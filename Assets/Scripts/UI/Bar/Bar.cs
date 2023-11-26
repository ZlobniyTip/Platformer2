using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] protected TMP_Text Text;

    private Coroutine _changeHealth;
    private float _recoveryRate = 0.2f;

    public void OnValueChanged(int value, int maxValue)
    {
        _changeHealth = StartCoroutine(ChangeHealthBar((float)value / maxValue));
        Text.text = $"{value}/{maxValue}";
    }

    private IEnumerator ChangeHealthBar(float target)
    {
        while (Slider.value != target)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, target, _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}