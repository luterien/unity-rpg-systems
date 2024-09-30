using System;

[Serializable]
public class Health
{
    private float _maxValue;
    private float _value;

    public float Ratio => (_value / _maxValue);
    public float Percentage => Ratio * 100f;

    public float Value => _value;
    public float MaxValue => _maxValue;

    public bool IsZero => _value <= 0f;

    public bool IsHealthBelowThresfold(float value) => Percentage <= value;

    public Health(float amount)
    {
        _maxValue = amount;
        _value = amount;
    }

    public float TakeDamage(float amount)
    {
        if (amount >= _value)
        {
            var healthLoss = _value;
            _value = 0f;
            return healthLoss;
        }

        _value -= amount;
        return amount;
    }

    public float RecoverHealth(float amount)
    {
        _value += amount;

        if (_value > _maxValue)
        {
            var recovered = amount - (_value - _maxValue);
            _value = _maxValue;
            return recovered;
        }

        return amount;
    }

    public void SetMaxHealth(float value)
    {
        var currentRatio = _value / _maxValue;

        _maxValue = value;
        _value = value * currentRatio;
    }

    public override string ToString()
    {
        return string.Format("{0}/{1}", (int)_value, (int)_maxValue);
    }
}