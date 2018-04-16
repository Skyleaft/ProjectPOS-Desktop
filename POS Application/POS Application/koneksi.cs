using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Application
{
    class koneksi
    {
        public SqlConnection dbkoneksi;
        public SqlCommand perintah;
        public SqlDataAdapter da;
        public DataTable dt;
        public DataSet ds;
        public String db = @"server=MILZAN-PC\SQLEXPRESS;database=ProjectPengolahanNilai;trusted_connection=true";
        public String sql;

        public void setdt()
        {
            dbkoneksi = new SqlConnection(db);
            perintah = new SqlCommand(sql, dbkoneksi);
            dt = new DataTable();
            da = new SqlDataAdapter(perintah);
            da.Fill(dt);
        }

        public void setds()
        {
            dbkoneksi = new SqlConnection(db);
            perintah = new SqlCommand(sql, dbkoneksi);
            ds = new DataSet();
            da = new SqlDataAdapter(perintah);
            da.Fill(ds, "tabel");

        }

        public void open()
        {
            dbkoneksi = new SqlConnection(db);
            dbkoneksi.Open();
        }
        public void close()
        {
            dbkoneksi = new SqlConnection(db);
            dbkoneksi.Close();
        }
    }
}

