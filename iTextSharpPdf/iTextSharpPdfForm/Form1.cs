using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTextSharpPdfForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"D:deneme.pdf",FileMode.Create));

                document.Open();

                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", "windows-1254", BaseFont.EMBEDDED);
                Font font = new Font(baseFont);

                PdfPTable table = new PdfPTable(4); //5 sütunlu bir tablo ekliyoruz.

                table.DefaultCell.Padding = 10;
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                PdfPCell cell = new PdfPCell(new Phrase("PDF"));

                cell.Padding = 10;
                cell.Colspan = 4;
                cell.HorizontalAlignment = 1;
                table.AddCell(cell);

                table.AddCell(new Phrase("1.Sütun", font));
                table.AddCell(new Phrase("2.Sütun", font));
                table.AddCell(new Phrase("3.Sütun", font));
                table.AddCell(new Phrase("4.Sütun", font));


                try
                {
                    document.Add(table);
                    document.Close();
                    writer.Close();
                    MessageBox.Show("PDF Olusturuldu.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                    
            }
        }
    }
}
