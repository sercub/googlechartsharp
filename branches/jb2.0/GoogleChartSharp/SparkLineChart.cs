namespace GoogleChartSharp
{
    ///<summary>A line chart with spark lines</summary>
    public class SparkLineChart : LineChart
    {
        /// <summary>
        /// Create a spark line chart with one line per dataset. Points are evenly spaced along the x-axis.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public SparkLineChart(int width, int height) : base(width, height)
        {
        }

        protected override string UrlChartType
        {
            get { return "ls"; }
        }
    }
}