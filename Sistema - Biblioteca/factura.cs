using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Sistema___Biblioteca
{
    public partial class Factura : Form
    {
        private PrintDocument PD = new PrintDocument();
        private PrintPreviewDialog PPD = new PrintPreviewDialog();
        private int longpaper;
        private Image logoImage;


        public Factura()
        {
            InitializeComponent();
            PD.BeginPrint += new PrintEventHandler(PD_BeginPrint);
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);

        }

        private void changelongpaper()
        {
            int rowcount = dataGridView1.Rows.Count;
            longpaper = rowcount * 15 + 240;
        }

        private void PD_BeginPrint(object sender, PrintEventArgs e)
        {
            PageSettings pagesetup = new PageSettings();
            pagesetup.PaperSize = new PaperSize("Custom", 250, longpaper);
            PD.DefaultPageSettings = pagesetup;
        }

        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font f8 = new Font("Calibri", 8, FontStyle.Regular);
            Font f10 = new Font("Calibri", 10, FontStyle.Regular);
            Font f10b = new Font("Calibri", 10, FontStyle.Bold);

            int leftmargin = PD.DefaultPageSettings.Margins.Left;
            int centermargin = PD.DefaultPageSettings.PaperSize.Width / 2;
            int rightmargin = PD.DefaultPageSettings.PaperSize.Width;

            StringFormat right = new StringFormat();
            StringFormat center = new StringFormat();
            right.Alignment = StringAlignment.Far;
            center.Alignment = StringAlignment.Center;

            string line = "****************************************************************";

            e.Graphics.DrawString("BookHub", f10, Brushes.Black, centermargin, 40, center);

            e.Graphics.DrawString("Factura N", f8, Brushes.Black, 0, 75);
            e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75);
            e.Graphics.DrawString("01234568", f8, Brushes.Black, 70, 75);

            e.Graphics.DrawString("Cajero", f8, Brushes.Black, 0, 85);
            e.Graphics.DrawString(":", f8, Brushes.Black, 50, 85);
            e.Graphics.DrawString("Liz Vazquez", f8, Brushes.Black, 70, 85);

            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString() + " - Hora: " + DateTime.Now.ToShortTimeString(), f8, Brushes.Black, 0, 95);
            e.Graphics.DrawString("Cant.", f8, Brushes.Black, 0, 110);
            e.Graphics.DrawString("Descripción.", f8, Brushes.Black, 35, 110);
            e.Graphics.DrawString("Nombre.", f8, Brushes.Black, 100, 110);

            e.Graphics.DrawString("Valor", f8, Brushes.Black, 180, 110, right);
            e.Graphics.DrawString("Total", f8, Brushes.Black, rightmargin, 110, right);

            e.Graphics.DrawString(line, f8, Brushes.Black, 0, 120);

            // ...

            // ...

            // ...

            int height = 0;
            decimal i;
            int lineHeight = 18; // Ajusta este valor según sea necesario

            dataGridView1.AllowUserToAddRows = false;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                height += lineHeight;

                // Dibujar la cantidad
                string cantidad = dataGridView1.Rows[row].Cells[0].Value?.ToString() ?? string.Empty;
                e.Graphics.DrawString(cantidad, f8, Brushes.Black, 0, 115 + height);

                // Dibujar la descripción (nombre del libro)
                string nombreLibro = dataGridView1.Rows[row].Cells[1].Value?.ToString() ?? string.Empty;
                e.Graphics.DrawString(nombreLibro, f8, Brushes.Black, 25, 115 + height);

                // Dibujar el nombre (del comprador)
                string nombreComprador = dataGridView1.Rows[row].Cells[3].Value?.ToString() ?? string.Empty;
                e.Graphics.DrawString(nombreComprador, f8, Brushes.Black, 100, 115 + height);

                i = Convert.ToDecimal(dataGridView1.Rows[row].Cells[2].Value);
                dataGridView1.Rows[row].Cells[2].Value = i.ToString("##,##0");

                // Dibujar el valor
                e.Graphics.DrawString(dataGridView1.Rows[row].Cells[2].Value.ToString(), f8, Brushes.Black, 180, 115 + height, right);

                decimal totalprice = Convert.ToDecimal(dataGridView1.Rows[row].Cells[1].Value) * Convert.ToDecimal(dataGridView1.Rows[row].Cells[2].Value);
                e.Graphics.DrawString(totalprice.ToString("##,##0"), f8, Brushes.Black, rightmargin, 115 + height, right);
            }

            // ...


            // ...


            // ... (código posterior)



            int height2 = 145 + height;
            sumprice();

            e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2);
            e.Graphics.DrawString("Total: " + t_price.ToString("##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right);
            e.Graphics.DrawString("Items: " + t_qty.ToString(), f10b, Brushes.Black, 0, 10 + height2);

            e.Graphics.DrawString("= GRACIAS POR PREFERIRNOS =", f10, Brushes.Black, centermargin, 70 + height2, center);
            e.Graphics.DrawString("= Documento generado por: BookHub - Biblioteca =", f8, Brushes.Black, centermargin, 85 + height2, center);
        }

        private decimal t_price;
        private int t_qty;

        private void sumprice()
        {
            decimal countprice = 0;
            for (int rowitem = 0; rowitem < dataGridView1.Rows.Count; rowitem++)
            {
                countprice += Convert.ToDecimal(dataGridView1.Rows[rowitem].Cells[2].Value) * Convert.ToDecimal(dataGridView1.Rows[rowitem].Cells[1].Value);
            }
            t_price = countprice;

            int countqty = 0;
            for (int rowitem = 0; rowitem < dataGridView1.Rows.Count; rowitem++)
            {
                countqty += Convert.ToInt32(dataGridView1.Rows[rowitem].Cells[1].Value);
            }
            t_qty = countqty;
        }

        private void BTREFRESH_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changelongpaper();
            PPD.Document = PD;
            PPD.ShowDialog();
            //PD.Print();
        }
    }
}
