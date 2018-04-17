using MaterialDesignColors.WpfExample.Domain;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS_Application
{
    /// <summary>
    /// Interaction logic for FormBarang.xaml
    /// </summary>
    public partial class FormBarang : UserControl
    {
        public FormBarang()
        {
            InitializeComponent();
        }

        koneksi k = new koneksi();

        public void showdata()
        {
            k.sql = "select id_barang from tb_barang";
            k.setdt();
            dg_barang.ItemsSource = k.dt.DefaultView;

        }

        public void bersih()
        {
            txt_hargabarang.Text = "";
            txt_kdbarang.Text = "";
            txt_merk.Text = "";
            txt_namabarang.Text = "";
            txt_stok.Text = "";
            cmb_kategori.Text="";
            dg_barang.UnselectAll();
        }

        private void btn_simpan_Click(object sender, RoutedEventArgs e)
        {
            if (txt_kdbarang.Text == "" || txt_namabarang.Text == "" || txt_merk.Text == "" || cmb_kategori.Text == "" || txt_hargabarang.Text == "" || txt_stok.Text == "")
            {
                var sampleMessageDialog = new SampleMessageDialog
                {
                    Message = { Text = "Lengkapi Dulu Data" }
                };
                DialogHost.Show(sampleMessageDialog, "MainDialog");
            }
            else
            {
                try
                {
                    k.sql = "insert into tb_barang select '" + txt_kdbarang.Text + "','" + txt_namabarang.Text + "','" + txt_merk.Text + "','" + cmb_kategori.Text + "','" + txt_hargabarang.Text + "','" + txt_stok.Text + "'";
                    k.setdt();

                    var sampleMessageDialog = new SampleMessageDialog
                    {
                        Message = { Text = "Data Berhasil Tersimpan" }
                    };
                    DialogHost.Show(sampleMessageDialog, "MainDialog");
                    showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Gagal Didaftarkan " + ex);
                }
            }
        }

        private void btn_batal_Click(object sender, RoutedEventArgs e)
        {
            bersih();
        }
    }
}
