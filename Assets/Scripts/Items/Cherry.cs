using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private int _currentHeal;

    public int Heal()
    {
        return _currentHeal;
    }
}
