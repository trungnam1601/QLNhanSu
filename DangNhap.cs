﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QLNhanSu
{
    public partial class DangNhap : Form
    {
        //Data source(khac nhau)
        string dataSource = @"Data Source=DESKTOP-152SFQ3;Initial Catalog=Quanlynhasu_3F;Integrated Security=True";

        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(dataSource);

            try
            {
                connection.Open();

                string taiKhoan = txtUsername.Text;
                string matKhau = txtPassword.Text;
                string sql = "select * from DANGNHAP where TaiKhoan = '"+taiKhoan+"' and MatKhau = '"+matKhau+"'";

                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    this.Hide();
                    ManHinhChinh manHinhChinh = new ManHinhChinh();
                    manHinhChinh.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }
    }
}
