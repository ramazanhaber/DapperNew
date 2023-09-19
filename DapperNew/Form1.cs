using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DapperNew
{
    public partial class Form1 : Form
    {
        // NuGet Managerdan dapper ve Dapper.Contrib  yükle

        public Form1()
        {
            InitializeComponent();
        }
        public static string connectionString = @"Server=RAMBO3;Database=Deneme1;User ID=sa;Password=19830126;";

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        public void listele()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var liste =  connection.Query<Ogrenciler>("SELECT * FROM Ogrenciler");
                gridControl1.DataSource = liste;
            }
        }
       
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenciler ogrenci=new Ogrenciler();
            ogrenci.ad = txtAd.Text;
            ogrenci.yas = Convert.ToInt32(txtYas.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ogrenciler (ad, yas) VALUES (@ad, @yas)";
                connection.Execute(query, ogrenci);
                //connection.ExecuteAsync(query, ogrenci); // hız için kullanılabilir
            }
            listele();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            Ogrenciler ogrenci = (Ogrenciler)gridView1.GetFocusedRow() as Ogrenciler;

            ogrenci.ad = txtAd.Text;
            ogrenci.yas = Convert.ToInt32(txtYas.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ogrenciler SET ad = @ad, yas = @yas WHERE id = @id";
                connection.Execute(query, ogrenci);
            }
            listele();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;

            Ogrenciler ogrenci = (Ogrenciler)gridView1.GetFocusedRow() as Ogrenciler;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ogrenciler WHERE id = @id";
                connection.Execute(query, new { id = ogrenci.id });
            }

            listele();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();

        }
    }
}
