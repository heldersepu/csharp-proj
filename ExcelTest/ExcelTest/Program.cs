using ClosedXML.Excel;
using Ionic.Zip;
using System.IO;
using System.Linq;

namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\file.xlsx";
            ClosedXMLTest(file);
        }

        static void ClosedXMLTest(string file)
        {
            string outFile = "fileClosedXML.xlsx";

            var workbook = new XLWorkbook(file);
            var dataWorksheet = workbook.Worksheet("data");
            for (int i = 1; i < 10; i++)
                dataWorksheet.Cell(i, i).Value = i;
            workbook.SaveAs(outFile);

            replaceSheet(outFile, file, "xl/worksheets/sheet1.xml");
        }

        static void replaceSheet(string outputFile, string inputFile, string sheetName)
        {
            using (var ozip = new ZipFile(outputFile))
            using (var izip = new ZipFile(inputFile))
            {
                var osheet = ozip.Entries.Where(x => x.FileName == sheetName).FirstOrDefault();
                var tempS = new MemoryStream();
                osheet.Extract(tempS);

                var isheet = izip.Entries.Where(x => x.FileName == sheetName).FirstOrDefault();
                izip.RemoveEntry(isheet);
                izip.AddEntry(isheet.FileName, tempS.ToArray());
                izip.Save();
            }
        }
    }
}
