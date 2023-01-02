namespace BIAB.Unity.Types
{
    public struct Range
    {
        public float max;
        public float min;

        public Range(float max, float min)
        {
            this.max = max;
            this.min = min;
        }
    }
}