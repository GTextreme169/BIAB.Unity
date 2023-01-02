namespace BIAB.Unity.Types
{
    /// <summary>
    /// Int That Rounds To Nearest Whole Number
    /// </summary>
    public class IntervalInt
    {
        private int _value;
        private int _modifier;
        public IntervalInt(int modifier, float value)
        {
            _modifier = modifier;
            Value = value;
        }

        public int Modifier
        {
            get => _modifier;
            set
            {
                if (value % _modifier == 0 || _modifier == value * value)
                {
                    _value *= UnityEngine.Mathf.RoundToInt((value * 1f) / (_modifier * 1f));
                    _modifier = value;
                }
                else
                    UnityEngine.Debug.LogWarning("Improper Modifier! Modifiers must be a multiple of previous modifier");
            }
        }

        public float Value
        {
            get => _value / (_modifier*1f);
            set => _value = UnityEngine.Mathf.RoundToInt(value * _modifier);
        }
    }
}