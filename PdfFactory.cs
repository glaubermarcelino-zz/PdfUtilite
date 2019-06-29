using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SitePdf.Util
{
    public class PdfFactory
    {
        public static MemoryStream PdfGenerate()
        {
            var ms = new MemoryStream();
            var doc = new Document(PageSize.A4);
            doc.SetMargins(45, 45, 45, 85);

            var pdf = PdfWriter.GetInstance(doc, ms);
            pdf.CloseStream = false;
            doc.Open();

            var util = new PdfUtilite(doc, pdf);

            util.AddGrid();
            doc.Close();
            var msInfo = ms.ToArray();
            ms.Write(msInfo, 0, msInfo.Length);

            ms.Position = 0;
            return ms;
        }
    }
}