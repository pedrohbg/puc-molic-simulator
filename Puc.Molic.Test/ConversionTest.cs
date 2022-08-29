using Puc.Molic.Model;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Puc.Molic.Test
{
    //Testing file Conversion and Object transformation
    //Author: Pedro Henrique Bof Gerico
    public class ConversionTest
    {

        //test converting object to XML
        [Fact]
        public void TestDiagramToXML()
        {
            DiagramFlow flow = new DiagramFlow();   
            var diagram = flow.GetDiagram();
            TransformationHelper transformationHelper = new TransformationHelper();
            string xml = transformationHelper.ToXML(diagram);

            Assert.False(string.IsNullOrWhiteSpace(xml));

        }



    }
}