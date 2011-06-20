namespace GoogleChartSharp
{
    ///<summary>
    /// Represents the numeric range of this axis
    ///</summary>
    public class AxisRange
    {
        /// <summary>
        /// The lowest value on the axis
        /// </summary>
        public int LowerBound { get; set; }
        /// <summary>
        /// The highest value on the axis
        /// </summary>
        public int UpperBound { get; set; }

        public string GetUrlPart()
        {
            return string.Format("{0},{1}", LowerBound, UpperBound);
        }
    }
}