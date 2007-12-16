using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public abstract class Chart
    {
        private const string API_BASE = "http://chart.apis.google.com/chart?";
        protected Queue<string> urlElements = new Queue<string>();

        public Chart(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        #region Chart Dimensions
        private int width;
        private int height;

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }
        #endregion

        #region Chart Data
        private string data;

        public void SetData(int[] data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(ICollection<int[]> data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(float[] data)
        {
            this.data = ChartData.Encode(data);
        }

        public void SetData(ICollection<float[]> data)
        {
            this.data = ChartData.Encode(data);
        }
        #endregion

        # region Chart Title
        private string title;
        private string titleColor;
        public void SetTitle(string title)
        {
            string urlTitle = title.Replace(" ", "+");
            urlTitle = urlTitle.Replace(Environment.NewLine, "|");
            this.title = urlTitle;
        }

        public void SetTitle(string title, string hexColor)
        {
            SetTitle(title);
            this.titleColor = hexColor;
        }

        public void SetTitle(string title, string hexColor, int fontSize)
        {
            SetTitle(title);
            this.titleColor = hexColor + "," + fontSize;
        }
        #endregion

        #region Colors
        private string[] datasetColors;

        public void SetDatasetColors(string[] datasetColors)
        {
            this.datasetColors = datasetColors;
        }

        #endregion

        # region Fills
        List<SolidFill> solidFills = new List<SolidFill>();
        List<LinearGradientFill> linearGradientFills = new List<LinearGradientFill>();
        List<LinearStripesFill> linearStripesFills = new List<LinearStripesFill>();

        public void AddSolidFill(SolidFill solidFill)
        {
            solidFills.Add(solidFill);
        }

        public void AddLinearGradientFill(LinearGradientFill linearGradientFill)
        {
            linearGradientFills.Add(linearGradientFill);
        }

        public void AddLinearStripesFill(LinearStripesFill linearStripesFill)
        {
            linearStripesFills.Add(linearStripesFill);
        }
        #endregion

        #region Grid
        bool gridSet = false;
        private float gridXAxisStepSize = -1;
        private float gridYAxisStepSize = -1;
        private float gridLengthLineSegment = -1;
        private float gridLengthBlankSegment = -1;

        public void SetGrid(float xAxisStepSize, float yAxisStepSize)
        {
            ChartType chartType = getChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            this.gridXAxisStepSize = xAxisStepSize;
            this.gridYAxisStepSize = yAxisStepSize;
            this.gridLengthLineSegment = -1;
            this.gridLengthBlankSegment = -1;
            this.gridSet = true;
        }

        public void SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment)
        {
            ChartType chartType = getChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            this.gridXAxisStepSize = xAxisStepSize;
            this.gridYAxisStepSize = yAxisStepSize;
            this.gridLengthLineSegment = lengthLineSegment;
            this.gridLengthBlankSegment = lengthBlankSegment;
            this.gridSet = true;
        }

        private string getGridUrlElement()
        {
            if (gridXAxisStepSize != -1 && gridYAxisStepSize != -1)
            {
                string s = String.Format("chg={0},{1}", gridXAxisStepSize.ToString(), gridYAxisStepSize.ToString());
                if (gridLengthLineSegment != -1 && gridLengthBlankSegment != -1)
                {
                    s += "," + gridLengthLineSegment.ToString() + "," + gridLengthBlankSegment.ToString();
                }
                return s;
            }
            return null;
        }

        #endregion

        #region Markers
        List<ShapeMarker> shapeMarkers = new List<ShapeMarker>();
        List<RangeMarker> rangeMarkers = new List<RangeMarker>();
        List<FillArea> fillAreas = new List<FillArea>();

        public void AddFillArea(FillArea fillArea)
        {
            this.fillAreas.Add(fillArea);
        }

        public void AddShapeMarker(ShapeMarker shapeMarker)
        {
            this.shapeMarkers.Add(shapeMarker);
        }

        public void AddRangeMarker(RangeMarker rangeMarker)
        {
            this.rangeMarkers.Add(rangeMarker);
        }

        private string getFillAreasUrlElement()
        {
            string s = string.Empty;
            foreach (FillArea fillArea in fillAreas)
            {
                s += fillArea.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        private string getShapeMarkersUrlElement()
        {
            string s = string.Empty;
            foreach (ShapeMarker shapeMarker in shapeMarkers)
            {
                s += shapeMarker.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        private string getRangeMarkersUrlElement()
        {
            string s = string.Empty;
            foreach (RangeMarker rangeMarker in rangeMarkers)
            {
                s += rangeMarker.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        #endregion

        #region Labels
        List<ChartAxis> axises = new List<ChartAxis>();
        List<string> legendStrings = new List<string>();

        public virtual void SetLegend(string[] strs)
        {
            foreach (string s in strs)
            {
                legendStrings.Add(s);
            }
        }

        public void AddAxis(ChartAxis axis)
        {
            axises.Add(axis);
        }
        #endregion

        public string GetUrl()
        {
            collectUrlElements();
            return generateUrlString();
        }

        public abstract string urlChartType();
        public abstract ChartType getChartType();

        protected virtual void collectUrlElements()
        {
            urlElements.Clear();
            urlElements.Enqueue(String.Format("cht={0}", this.urlChartType()));
            urlElements.Enqueue(String.Format("chs={0}x{1}", this.width, this.height));
            urlElements.Enqueue(this.data);
            if (title != null)
            {
                urlElements.Enqueue(String.Format("chtt={0}", this.title));
            }
            if (titleColor != null)
            {
                urlElements.Enqueue(String.Format("chts={0}", this.titleColor));
            }
            if (datasetColors != null)
            {
                string s = "chco=";
                foreach (string color in datasetColors)
                {
                    s += color + ",";
                }
                urlElements.Enqueue(s.TrimEnd(",".ToCharArray()));
            }

            // Fills
            string fillsString = "chf=";
            if (solidFills.Count > 0)
            {
                foreach (SolidFill solidFill in solidFills)
                {
                    fillsString += solidFill.GetUrlString() + "|";
                }
            }
            if (linearGradientFills.Count > 0)
            {
                foreach (LinearGradientFill linearGradient in linearGradientFills)
                {
                    fillsString += linearGradient.GetUrlString() + "|";
                }
            }
            if (linearStripesFills.Count > 0)
            {
                foreach (LinearStripesFill linearStripesFill in linearStripesFills)
                {
                    fillsString += linearStripesFill.GetUrlString() + "|";
                }
            }
            if (solidFills.Count > 0 || linearGradientFills.Count > 0 || linearStripesFills.Count > 0)
            {
                urlElements.Enqueue(fillsString.TrimEnd("|".ToCharArray()));
            }

            // Legends
            if (legendStrings.Count > 0)
            {
                string s = "chdl=";
                foreach (string str in legendStrings)
                {
                    s += str + "|";
                }
                urlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
            if (axises.Count > 0)
            {
                string axisTypes = "chxt=";
                string axisLabels = "chxl=";
                string axisLabelPositions = "chxp=";
                string axisRange = "chxr=";
                string axisStyle = "chxs=";

                int axisIndex = 0;
                foreach (ChartAxis axis in axises)
                {
                    axisTypes += axis.urlAxisType() + ",";
                    axisLabels += axisIndex.ToString() + ":" + axis.urlLabels();
                    string labelPositions = axis.urlLabelPositions();
                    if (! String.IsNullOrEmpty(labelPositions))
                    {
                        axisLabelPositions += axisIndex.ToString() + "," + labelPositions + "|";
                    }
                    string axisRangeStr = axis.urlRange();
                    if (!String.IsNullOrEmpty(axisRangeStr))
                    {
                        axisRange += axisIndex.ToString() + "," + axisRangeStr + "|";
                    }
                    string axisStyleStr = axis.UrlAxisStyle();
                    if (!String.IsNullOrEmpty(axisStyleStr))
                    {
                        axisStyle += axisIndex.ToString() + "," + axisStyleStr + "|";
                    }
                    axisIndex++;
                }
                axisTypes = axisTypes.TrimEnd(",".ToCharArray());
                axisLabels = axisLabels.TrimEnd("|".ToCharArray());
                axisLabelPositions = axisLabelPositions.TrimEnd("|".ToCharArray());
                axisRange = axisRange.TrimEnd("|".ToCharArray());
                axisStyle = axisStyle.TrimEnd("|".ToCharArray());

                urlElements.Enqueue(axisTypes);
                urlElements.Enqueue(axisLabels);
                urlElements.Enqueue(axisLabelPositions);
                urlElements.Enqueue(axisRange);
                urlElements.Enqueue(axisStyle);
            }

            // Grid
            if (gridSet)
            {
                urlElements.Enqueue(getGridUrlElement());
            }
            
            // Markers
            string markersString = "chm=";
            if (shapeMarkers.Count > 0)
            {
                markersString += getShapeMarkersUrlElement() + "|";
            }
            if (rangeMarkers.Count > 0)
            {
                markersString += getRangeMarkersUrlElement() + "|";
            }
            if (fillAreas.Count > 0)
            {
                markersString += getFillAreasUrlElement() + "|";
            }
            if (shapeMarkers.Count > 0 || rangeMarkers.Count > 0 || fillAreas.Count > 0)
            {
                urlElements.Enqueue(markersString.TrimEnd("|".ToCharArray()));
            }
        }

        private string generateUrlString()
        {
            string url = string.Empty;

            url += Chart.API_BASE;
            url += urlElements.Dequeue();

            while (urlElements.Count > 0)
            {
                url += "&" + urlElements.Dequeue();
            }

            return url;
        }

        
    }

    public class InvalidFeatureForChartTypeException : Exception
    {
    }

    public enum ChartType
    {
        LineChart,
        ScatterPlot,
        BarChart,
        VennDiagram,
        PieChart
    }
}
