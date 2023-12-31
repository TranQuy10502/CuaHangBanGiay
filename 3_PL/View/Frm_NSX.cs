﻿using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL.View
{
    public partial class Frm_NSX : Form
    {
        private INsxServices insx;
        private NsxViewModels viewnsx;

        
        public Frm_NSX()
        {
            InitializeComponent();
            insx = new NsxServices();
            viewnsx = new NsxViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_showsize.Rows.Clear();
            dgv_showsize.ColumnCount = 4;
            dgv_showsize.Columns[0].Name = "ID";
            dgv_showsize.Columns[0].Visible= false;
            dgv_showsize.Columns[1].Name = "Mã";
            dgv_showsize.Columns[2].Name = "Tên nhà sản xuất";
            dgv_showsize.Columns[3].Name = "Trạng thái";
            var lstnssx = insx.GetNhasanxuat();
            if (tb_timkiem.Text != "")
            {
                lstnssx = lstnssx.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower()) 
                || x.Ten.ToLower().Contains(tb_timkiem.Text.ToLower())).ToList();
            }
            foreach (var item in lstnssx)
            {
                dgv_showsize.Rows.Add(item.Id,item.Ma,item.Ten,item.TrangThai== 1 ? "Còn sản xuất": "Ngừng sản xuất");
            }
            dgv_showsize.AllowUserToAddRows = false;
        }

        
        private void btn_sua_Click(object sender, EventArgs e)
        {
            //viewnsx.Ma = tb_ma.Text;
            //viewnsx.Ten = tb_ten.Text;
            //viewnsx.TrangThai = rdb_con.Checked ? 1 : 0;
            //MessageBox.Show(insx.update(viewnsx));
            //loadData();

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Nhà Sản Xuất Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (viewnsx == null)
                {
                    MessageBox.Show("bạn chưa chọn nsx");
                }
                else
                {
                    MessageBox.Show(insx.remove(viewnsx));
                    loadData();
                }
            }

        }
        

        private void dgv_showsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_showsize.Rows[e.RowIndex];
                viewnsx = insx.GetNhasanxuat().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                tb_ma.Text = viewnsx.Ma;
                tb_ten.Text = viewnsx.Ten;
                if (dgvr.Cells[3].Value.ToString() == "Còn sản xuất") 
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_ngung.Checked = true;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (insx.GetNhasanxuat().Any(c => c.Ma == tb_ma.Text))
                {
                    MessageBox.Show("Mã bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(tb_ten.Text))
                {
                    MessageBox.Show("Tên không được bỏ trống");
                }
                else if (rdb_con.Checked == false && rdb_ngung.Checked == false)
                {

                    MessageBox.Show("Vui lòng chọn trạng thái");
                }
                else
                {
                    NsxViewModels x = new NsxViewModels()
                    {
                        Id = Guid.NewGuid(),
                        Ma = tb_ma.Text,
                        Ten = tb_ten.Text,
                        TrangThai = rdb_con.Checked ? 1 : 0
                    };
                    MessageBox.Show(insx.add(x));
                    loadData();
                }
            }
        }

        private void tb_sosize_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Sửa Nhà Sản Xuất Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                viewnsx.Ma = tb_ma.Text;
                viewnsx.Ten = tb_ten.Text;
                viewnsx.TrangThai = rdb_con.Checked ? 1 : 0;
                MessageBox.Show(insx.update(viewnsx));
                loadData();
            }
        }

        private void dgv_showsize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
