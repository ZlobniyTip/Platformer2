using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Image _healthBarFilling;

    private Coroutine _changeHealth;
    private float _recoveryRate = 0.2f;

    public void OnValueChanged(int value, int maxValue)
    {
        _changeHealth = StartCoroutine(ChangeHealthBar((float)value / maxValue));
    }

    private IEnumerator ChangeHealthBar(float target)
    {
        while (_healthBarFilling.fillAmount != target)
        {
            _healthBarFilling.fillAmount = Mathf.MoveTowards(_healthBarFilling.fillAmount, target, _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}