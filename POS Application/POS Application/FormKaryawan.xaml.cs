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
    /// Interaction logic for FormKaryawan.xaml
    /// </summary>
    public partial class FormKaryawan : UserControl
    {
        public FormKaryawan()
        {
            InitializeComponent();
            showdata();

        }

        koneksi k = new koneksi();
        private String alamat_foto;

        public void showdata()
        {
            k.sql = "select foto,id_karyawan,nama,jenis_kelamin from tb_karyawan";
            k.setdt();
            dg_kar.ItemsSource = k.dt.DefaultView;

        }

        public void bersih()
        {
            txt_alamat.Text = "";
            txt_nama.Text = "";
            txt_kdkar.Text = "";
            txt_nohp.Text = "";
            txt_tempatlhr.Text = "";
            cmb_agama.Text = "";
            cmb_jabatan.Text = "";
            rb_laki.IsChecked = false;
            rb_perempuan.IsChecked = false;
            dp_tgllahir.Text = "";
            img_foto.Source = null;
            dg_kar.UnselectAll();
        }

        private void btn_ambil_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Masukan Foto";
            op.Filter = "Semua Gambar|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                alamat_foto = op.FileName;
                img_foto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void btn_simpan_Click(object sender, RoutedEventArgs e)
        {
            if (txt_kdkar.Text == "" || txt_nama.Text == "" || txt_nohp.Text == "" || txt_alamat.Text == "" || txt_tempatlhr.Text == "" || dp_tgllahir.Text == "" || cmb_agama.Text == "" || cmb_jabatan.Text == "")
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
                    DateTime tglahir = dp_tgllahir.SelectedDate.Value;
                    String jk = "";
                    if (rb_laki.IsChecked == true)
                    {
                        jk = "Laki - Laki";
                    }
                    else
                    {
                        jk = "Perempuan";
                    }
                    k.sql = "insert into tb_karyawan select '" + txt_kdkar.Text + "','" + txt_nama.Text + "','" + jk + "','" + tglahir.ToString("MM-dd-yyyy") + "','" + txt_tempatlhr.Text + "','" + txt_alamat.Text + "','" + cmb_agama.Text + "','" + txt_nohp.Text + "','" + cmb_jabatan.Text + "',bulkcolumn from openrowset(bulk'" + alamat_foto + "',single_blob) as gambar";
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
    }
}
