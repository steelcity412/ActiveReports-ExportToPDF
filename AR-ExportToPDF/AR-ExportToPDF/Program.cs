using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AR_ExportToPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Provide the page report you want to render.
            System.IO.FileInfo rptPath = new System.IO.FileInfo(@"..\..\reports\Categories.rdlx");
            GrapeCity.ActiveReports.PageReport pageReport = new GrapeCity.ActiveReports.PageReport(rptPath);

            // Create an output directory.
            System.IO.DirectoryInfo outputDirectory = new System.IO.DirectoryInfo(@"..\..\ActiveReportsPDF");
            outputDirectory.Create();

            // Provide settings for your rendering output.
            GrapeCity.ActiveReports.Export.Pdf.Page.Settings pdfSetting = new GrapeCity.ActiveReports.Export.Pdf.Page.Settings();

            // Set the rendering extension and render the report.
            GrapeCity.ActiveReports.Export.Pdf.Page.PdfRenderingExtension pdfRenderingExtension = new GrapeCity.ActiveReports.Export.Pdf.Page.PdfRenderingExtension();
            GrapeCity.ActiveReports.Rendering.IO.FileStreamProvider outputProvider = new GrapeCity.ActiveReports.Rendering.IO.FileStreamProvider(outputDirectory, System.IO.Path.GetFileNameWithoutExtension(outputDirectory.Name));

            // Overwrite output file if it already exists
            outputProvider.OverwriteOutputFile = true;

            pageReport.Document.Render(pdfRenderingExtension, outputProvider, pdfSetting);
        }
    }
}
