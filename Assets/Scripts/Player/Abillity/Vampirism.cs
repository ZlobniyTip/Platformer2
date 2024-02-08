using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private int _damagePerSecond;
    [SerializeField] private float _spellDuration;

    private Coroutine _vampirismCast;

    private int _frequencyDamage = 1;
    private float _spellDurationTimer;

    public void ActivateSpell(Collider2D enemy)
    {
        _vampirismCast = StartCoroutine(ActivateVampirism(enemy));
    }

    public void DeactivateSpell()
    {
        if (_vampirismCast != null)
        {
            StopCoroutine(_vampirismCast);
        }
    }

    private IEnumerator ActivateVampirism(Collider2D enemy)
    {
        var delayBeforeDamage = new WaitForSeconds(_frequencyDamage);
        var target = enemy.GetComponent<Enemy>();

        while (_spellDurationTimer < _spellDuration)
        {
            target.TakeDamage(_damagePerSecond);
            _healthPlayer.Heal(_damagePerSecond);

            _spellDurationTimer += _frequencyDamage;

            yield return delayBeforeDamage;
        }
    }
}
