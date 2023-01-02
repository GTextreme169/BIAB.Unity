namespace BIAB.Unity.Types
{
    public class TrackedString
    {
        public delegate void OnStringChangeDelegate(string newVal);
        public event OnStringChangeDelegate OnStringChange;
        private string _trackedValue;
        
        public string Value
        {
            get => _trackedValue;
            set
            {
                if (_trackedValue != value)
                    if (OnStringChange != null) OnStringChange(value);
                _trackedValue = value;
            }
        }
        
        public string ValueOrDefault(string defaultValue)
        {
            return Value ?? defaultValue;
        }

        public TrackedString(string str = null)
        {
            _trackedValue = str;
        }


        public static implicit operator string(TrackedString rhs)
        {
            return rhs.Value;
        }
        public static implicit operator TrackedString(string rhs)
        {
            return new TrackedString(rhs);
        }

    }
}