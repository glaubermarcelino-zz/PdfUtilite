using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfUtilite
{
    public class PdfUtilite
    {
        protected PdfUtilite()
        {
        }

        protected static void Rectangle(PdfContentByte cb, float xInit, float yInit, float width, float height, float radius)
        {
            cb.RoundRectangle(xInit, yInit, width, height, radius);
            cb.SetLineWidth(0.12f);
            cb.Stroke();
        }

        protected static Rectangle Rectangle(float xInfEsq, float yInfEsq, float xSupDir, float ySupDir)
        {
            return new Rectangle(xInfEsq, yInfEsq, xSupDir, ySupDir)
            {
                Border = iTextSharp.text.Rectangle.BOX,
                BorderWidth = 0.5f
            };
        }

        protected static void HLine(PdfContentByte cb, float position)
        {
            cb.MoveTo(40, position);
            cb.LineTo(550, position);
            cb.Stroke();
        }

        protected static void VLine(PdfContentByte cb, float xInit, float yInit, float xFinal, float yFinal)
        {

            cb.MoveTo(xInit, yInit);
            cb.LineTo(xFinal, yFinal);
            cb.Stroke();
        }

        protected static void Text(PdfWriter pdf, string text, string nameFont, int sizeFont, float positionX, float positionY)
        {
            var cb = pdf.DirectContent;
            var bf = BaseFont.CreateFont(nameFont, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.Black);
            cb.SetFontAndSize(bf, sizeFont);
            cb.BeginText();
            cb.ShowTextAligned(Element.ALIGN_CENTER, text, positionX, positionY, 0);
            cb.EndText();
        }


        protected static Paragraph Text(string text, int sizeFont, int alignText)
        {
            var helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            return new Paragraph(text)
            {
                Alignment = alignText,
                Font = new Font(helvetica, sizeFont, Font.NORMAL, BaseColor.Black),

            };

        }

        protected static Paragraph TextCenter(string text, int sizeFOnt)
        {
            var helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            return new Paragraph(text)
            {
                Alignment = Element.ALIGN_CENTER,
                Font = new Font(helvetica, sizeFOnt, Font.NORMAL, BaseColor.Black)
            };

        }

        protected static Paragraph TextJustified(string text, int sizeFont)
        {
            var helvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            return new Paragraph(text)
            {
                Alignment = Element.ALIGN_JUSTIFIED,
                Font = new Font(helvetica, sizeFont, Font.NORMAL, BaseColor.Black)
            };
        }

        protected static void AddGrid(Document doc, PdfWriter pdf)
        {
            AddGrid(doc, pdf, true);
        }

        protected static void AddGrid(Document doc, PdfWriter pdf, bool activate)
        {
            if (activate)
            {
                var cb = pdf.DirectContent;
                var bf = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.DarkGray);
                cb.SetFontAndSize(bf, 8);
                cb.SetLineDash(1f, 1f);
                cb.BeginText();

                for (float i = 0; i < doc.PageSize.Height; i++)
                {
                    if (i % 50 == 0)
                    {
                        cb.ShowTextAligned(1, i.ToString(), 8, i, 0);
                    }
                }

                for (float i = 0; i < doc.PageSize.Width; i++)
                {
                    if (i % 50 == 0)
                    {
                        cb.ShowTextAligned(1, i.ToString(), i, doc.PageSize.Height - 10, 0);
                    }
                }

                cb.EndText();

                for (float i = 0; i < doc.PageSize.Height; i++)
                {
                    if (i % 50 == 0)
                    {
                        cb.MoveTo(0, i);
                        cb.LineTo(doc.PageSize.Width, i);
                    }
                }

                for (float i = 0; i < doc.PageSize.Width; i++)
                {
                    if (i % 50 == 0)
                    {
                        cb.MoveTo(i, 0);
                        cb.LineTo(i, doc.PageSize.Height);
                    }
                }

                cb.Stroke();

            }
        }
    }
}
