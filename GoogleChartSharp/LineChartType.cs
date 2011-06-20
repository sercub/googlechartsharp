namespace GoogleChartSharp
{
    /// <summary>
    /// Specifies how the line chart handles datasets
    /// </summary>
    public enum LineChartType
    {
        /// <summary>
        /// One line per dataset, points are evenly spaced along the x-axis
        /// </summary>
        SingleDataSet,

        /// <summary>
        /// Two datasets per line. The first dataset is the x coordinates 
        /// of the line. The second dataset is the Y coordinates of the line.
        /// </summary>
        MultiDataSet,

        /// <summary>
        /// A sparkline chart has exactly the same parameters as a line chart. 
        /// The only difference is that the axes lines are not drawn for sparklines 
        /// by default. You can add axes labels if you wish.
        /// </summary>
        Sparklines
    }
}