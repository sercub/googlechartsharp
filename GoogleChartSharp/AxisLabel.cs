namespace GoogleChartSharp
{
    /// <summary>
    /// Describes an axis label
    /// </summary>
    public class AxisLabel
    {
        public AxisLabel()
        {
            Text = "";
        }

        public AxisLabel(string text)
        {
            Text = text;
        }
        public AxisLabel(string text, float position)
        {
            Text = text;
            Position = position;
        }
        /// <summary>
        /// This text will be displayed on the axis
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A value within the axis range
        /// </summary>
        public float? Position { get; set; }
    }
}