using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SitePdf.Util
{
    public class PdfUtilite
    {
        private Document _doc;
        public string NameFont { private get; set; }
        public int SizeFont { get; set; }


        public PdfContentByte PdfContentByte;

        internal PdfUtilite(Document doc, PdfWriter pdf)
        {
            this._doc = doc;
            this.PdfContentByte = pdf.DirectContent;
        }

        internal BaseFont GetFont(string font)
        {
            return BaseFont.CreateFont(font, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        }

        internal BaseFont GetFont()
        {
            return BaseFont.CreateFont(this.NameFont ?? BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        }


        internal void AddImage(string path, float fitWidth, float fitHeight, float absoluteX, float absoluteY)
        {
            var st = File.Open(path, FileMode.Open);

            var image = Image.GetInstance(st);
            image.ScaleToFit(fitWidth, fitHeight);
            image.SetAbsolutePosition(absoluteX, absoluteY);
            this._doc.Add(image);
        }

        internal void TextColumn(string text, string nameFont, int sizeFont, float xInfEsq, float yInfEsq, float xSupDir, float ySupDir)
        {
            var ct = new ColumnText(this.PdfContentByte);

            ct.SetSimpleColumn(xInfEsq, yInfEsq, xSupDir, ySupDir);
            ct.AddElement(TextJustified(text, nameFont, sizeFont));
            ct.Go();
        }

        internal void Rectangle(float xInit, float yInit, float width, float height, float widthLine, float radius)
        {
            this.PdfContentByte.RoundRectangle(xInit, yInit, width, height, radius);
            this.PdfContentByte.SetLineWidth(widthLine);
            this.PdfContentByte.Stroke();
        }

        internal void HLine(float position)
        {
            this.PdfContentByte.MoveTo(this._doc.LeftMargin, position);
            this.PdfContentByte.LineTo(this._doc.PageSize.Width - this._doc.RightMargin, position);
            this.PdfContentByte.Stroke();
        }

        internal void VLine(float x, float yInit, float yFinal)
        {
            this.PdfContentByte.MoveTo(x, yInit);
            this.PdfContentByte.LineTo(x, yFinal);
            this.PdfContentByte.Stroke();
        }

        internal void TextCenter(string text, string nameFont, int sizeFont, float positionX, float positionY)
        {
            var bf = GetFont(nameFont);
            this.PdfContentByte.SetColorFill(BaseColor.Black);
            this.PdfContentByte.SetFontAndSize(bf, sizeFont);
            this.PdfContentByte.BeginText();
            this.PdfContentByte.ShowTextAligned(Element.ALIGN_CENTER, text, positionX, positionY, 0);
            this.PdfContentByte.EndText();
        }

        internal void TextRigth(string text, string nameFont, int sizeFont, float positionX, float positionY)
        {
            var bf = GetFont(nameFont);
            this.PdfContentByte.SetColorFill(BaseColor.Black);
            this.PdfContentByte.SetFontAndSize(bf, sizeFont);
            this.PdfContentByte.BeginText();
            this.PdfContentByte.ShowTextAligned(Element.ALIGN_LEFT, text, positionX, positionY, 0);
            this.PdfContentByte.EndText();
        }

        internal void TextLeft(string text, string nameFont, int sizeFont, float positionX, float positionY)
        {
            var bf = GetFont(nameFont);
            this.PdfContentByte.SetColorFill(BaseColor.Black);
            this.PdfContentByte.SetFontAndSize(bf, sizeFont);
            this.PdfContentByte.BeginText();
            this.PdfContentByte.ShowTextAligned(Element.ALIGN_RIGHT, text, positionX, positionY, 0);
            this.PdfContentByte.EndText();
        }

        internal Paragraph Text(string text, string nameFont, int sizeFont, int alignText)
        {
            var font = GetFont(nameFont);
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = alignText;

            return paragraph;
        }

        internal Paragraph TextCenter(string text, string nameFont, int sizeFont)
        {
            var font = GetFont(nameFont);
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_CENTER;

            return paragraph;

        }

        internal Paragraph TextCenter(string text, int sizeFont)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_CENTER;

            return paragraph;

        }

        internal Paragraph TextCenter(string text)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, this.SizeFont != 0 ? this.SizeFont : 12, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_CENTER;

            return paragraph;

        }

        internal Paragraph TextJustified(string text, string nameFont, int sizeFont)
        {
            var font = GetFont(nameFont);
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            return paragraph;
        }

        internal Paragraph TextJustified(string text, int sizeFont)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            return paragraph;
        }

        internal Paragraph TextJustified(string text)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, this.SizeFont != 0 ? this.SizeFont : 12, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            return paragraph;
        }

        internal Paragraph TextLeft(string text, string nameFont, int sizeFont)
        {
            var font = GetFont(nameFont);
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_LEFT;

            return paragraph;
        }

        internal Paragraph TextLeft(string text, int sizeFont)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_LEFT;

            return paragraph;
        }

        internal Paragraph TextLeft(string text)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, this.SizeFont != 0 ? this.SizeFont : 12, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_LEFT;

            return paragraph;
        }


        internal Paragraph TextRigth(string text, int sizeFont, string nameFont)
        {
            var font = GetFont(nameFont);
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_RIGHT;

            return paragraph;
        }

        internal Paragraph TextRigth(string text, int sizeFont)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, sizeFont, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_RIGHT;

            return paragraph;
        }
        internal Paragraph TextRigth(string text)
        {
            var font = GetFont();
            var paragraph = new Paragraph(text, new Font(font, this.SizeFont != 0 ? this.SizeFont : 12, Font.NORMAL, BaseColor.Black));
            paragraph.Alignment = Element.ALIGN_RIGHT;

            return paragraph;
        }

        internal void AddGrid()
        {
            AddGrid(true);
        }

        internal void AddGrid(bool activate)
        {
            if (activate)
            {
                var bf = GetFont(BaseFont.COURIER);
                this.PdfContentByte.SetColorFill(BaseColor.DarkGray);
                this.PdfContentByte.SetFontAndSize(bf, 8);
                this.PdfContentByte.SetLineDash(1f, 1f);
                this.PdfContentByte.BeginText();

                for (float i = 0; i < this._doc.PageSize.Height; i++)
                {
                    if (i % 50 == 0)
                    {
                        this.PdfContentByte.ShowTextAligned(1, i.ToString(), 8, i, 0);
                    }
                }

                for (float i = 0; i < this._doc.PageSize.Width; i++)
                {
                    if (i % 50 == 0)
                    {
                        this.PdfContentByte.ShowTextAligned(1, i.ToString(), i, this._doc.PageSize.Height - 10, 0);
                    }
                }

                this.PdfContentByte.EndText();

                for (float i = 0; i < this._doc.PageSize.Height; i++)
                {
                    if (i % 50 == 0)
                    {
                        this.PdfContentByte.MoveTo(0, i);
                        this.PdfContentByte.LineTo(this._doc.PageSize.Width, i);
                    }
                }

                for (float i = 0; i < this._doc.PageSize.Width; i++)
                {
                    if (i % 50 == 0)
                    {
                        this.PdfContentByte.MoveTo(i, 0);
                        this.PdfContentByte.LineTo(i, this._doc.PageSize.Height);
                    }
                }

                this.PdfContentByte.Stroke();

            }

        }
    }
}
