using System.Diagnostics;
using GoogleChartSharp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VennDiagramTests
    {
        [Test]
        public void VennDiagramTest()
        {
            int[] data = new int[] { 100, 80, 60, 30, 30, 30, 10 };

            VennDiagram vennDiagram = new VennDiagram(150, 150);
            vennDiagram.Title = "Venn Diagram";
            vennDiagram.Data = data;

            var actual = vennDiagram.GetUrl();
            var expected = "http://chart.apis.google.com/chart?cht=v&chs=150x150&chd=e:BkBQA8AeAeAeAK&chtt=Venn+Diagram";
            Assert.AreEqual(expected, actual);

            
        }
    }
}
