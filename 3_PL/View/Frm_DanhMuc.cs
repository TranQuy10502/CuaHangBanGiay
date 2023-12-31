﻿using System;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace _3_PL.View
{
    public partial class Frm_DanhMuc : Form
    {
        public IDanhMucServices DanhMucServices;
        public List<DanhMucViewModels> _DanhMucViewModels;
        public DanhMucViewModels _DanhMucView;
        public Frm_DanhMuc()
        {
            InitializeComponent();
            DanhMucServices = new DanhMucServices();
            _DanhMucViewModels = new List<DanhMucViewModels>();
            LoadDTG();
            loadCBB();

        }
        public void loadCBB()
        {
            foreach (var item in DanhMucServices.GetDanhMuc())
            {
                cbb_danhmucKhac.Items.Add(item.Ten);
            }
        }
        public void LoadDTG()
        {
            int stt = 1;
            dgv_showsize.ColumnCount = 6;
            dgv_showsize.Columns[0].Name = "ID";
            dgv_showsize.Columns[0].Visible = false;
            dgv_showsize.Columns[1].Name = "STT";
            dgv_showsize.Columns[2].Name = "Mã danh mục";
            dgv_showsize.Columns[3].Name = "Tên Danh mục";
            dgv_showsize.Columns[4].Name = "Danh mục khác";
            dgv_showsize.Columns[5].Name = "Trạng thái";
            dgv_showsize.Rows.Clear();
            _DanhMucViewModels = DanhMucServices.GetDanhMuc();
            foreach (var item in _DanhMucViewModels)
            {
                dgv_showsize.Rows.Add(
                    item.Id,
                    stt++,
                    item.Ma,
                    item.Ten,
                    item.IdDanhMucKhac != null ? DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Id == item.IdDanhMucKhac).Ten : null,
                    item.TrangThai == 1 ? "Hiển thị" : "Ẩn"
                    );
            }
            dgv_showsize.AllowUserToAddRows = false;

        }
        private Guid idDM;
        private void dgv_showsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgv_showsize.Rows[e.RowIndex];
                _DanhMucView = DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Id == Guid.Parse(r.Cells[0].Value.ToString()));
                idDM = Guid.Parse(r.Cells[0].Value.ToString());
                tb_ma.Text = r.Cells[2].Value.ToString();
                tb_ten.Text = r.Cells[3].Value.ToString();
                //      cbb_danhmucKhac.Text = r.Cells[4].Value.ToString();
                cbb_danhmucKhac.Text = _DanhMucView.IdDanhMucKhac != null ? DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Id == _DanhMucView.IdDanhMucKhac).Ten : null;
                if (r.Cells[5].Value.ToString() == "Hiển thị")
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_ngung.Checked = true;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var iddmk = DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cbb_danhmucKhac.Text).Id;
            if (idDM == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn danh mục");
            }
            else
            {
                DanhMucViewModels dm = new DanhMucViewModels()
                {
                    Id = idDM,
                    Ma = tb_ma.Text,
                    Ten = tb_ten.Text,
                 //   IdDanhMucKhac = cbb_danhmucKhac.Text != "" ? DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cbb_danhmucKhac.Text).Id : null,
                    IdDanhMucKhac = cbb_danhmucKhac.Text != "" ? iddmk : null ,
                    TrangThai = rdb_con.Checked ? 1 : 0
                };
                MessageBox.Show(DanhMucServices.update(dm));
                LoadDTG();
            }

        }
        //public void EnumAllSubitems(DanhMucViewModels subItem, Action<BarItem, DanhMucViewModels> callback)
        //{
        //    foreach (BarItemLink link in subItem.ItemLinks)
        //    {
        //        DanhMucViewModels item = link.Item;

        //        callback(item, subItem);
        //        if (item is BarSubItem)
        //        {
        //            EnumAllSubitems((BarSubItem)item, callback);
        //        }
        //    }

        //}
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!rdb_con.Checked && !rdb_ngung.Checked)
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
            }else if(DanhMucServices.GetDanhMuc().Any(p=>p.Ten == tb_ten.Text))
            {
                MessageBox.Show("Tên Danh Mục Đã Tồn Tại");
            }
            else if (DanhMucServices.GetDanhMuc().Any(p => p.Ma == tb_ma.Text))
            {
                MessageBox.Show("Tên Danh Mục Đã Tồn Tại");
            }
            else if(tb_ma.Text =="" || tb_ten.Text =="")
            {
                MessageBox.Show("Bạn Chưa Nhập đầy đủ thông tin");
            }
            else
            {
                var dm = new DanhMucViewModels()
                {
                    Id = new Guid(),
                    Ma = tb_ma.Text,
                    Ten = tb_ten.Text,
                    IdDanhMucKhac = cbb_danhmucKhac.Text != "" ? DanhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cbb_danhmucKhac.Text).Id : null,
                    TrangThai = rdb_con.Checked ? 1 : 0,

                };
                DanhMucServices.add(dm);
            }
       
            LoadDTG();
        }
    }
}
