﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;

namespace QLNHANSU
{
    public partial class frmNhanVien_ThoiViec : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien_ThoiViec()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD;
        NHANVIEN_THOIVIEC _nvtv;
        NHANVIEN _nhanvien;

        private void frmNhanVien_ThoiViec_Load(object sender, EventArgs e)
        {
            _nvtv = new NHANVIEN_THOIVIEC();
            _nhanvien = new NHANVIEN();
            _them = false;
            loadData();
            loadNhanVien();
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            gcDanhSach.Enabled = kt;
            txtSoQD.Enabled = !kt;
            txtLyDo.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            dtNgayNopDon.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _nvtv.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dtNgayNopDon.Value = DateTime.Now;
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(45);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false);
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            splitContainer1.Panel1Collapsed = false;
            gcDanhSach.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nvtv.Delete(_soQD, 1);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close(); 
        }
        void SaveData()
        {
            tb_NHANVIEN_THOIVIEC tv;
            if (_them)
            {
                var maxSoQD = _nvtv.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;

                tv = new tb_NHANVIEN_THOIVIEC();
                tv.SOQD = so.ToString("00000") + @"/" + DateTime.Now.Year.ToString() + @"/QĐTV";
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                tv.CREATED_BY = 1;
                tv.CREATED_DATE = DateTime.Now;
                _nvtv.Add(tv);
            }
            else
            {
                tv = _nvtv.getItem(_soQD);
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                tv.UPDATED_BY = 1;
                tv.UPDATED_DATE = DateTime.Now;
                _nvtv.Update(tv);
            }
            var nv = _nhanvien.getItem(tv.MANV.Value);
            nv.DATHOIVIEC = true;
            _nhanvien.Update(nv);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var tv = _nvtv.getItem(_soQD);
                txtSoQD.Text = _soQD;
                dtNgayNopDon.Value = tv.NGAYNOPDON.Value;
                dtNgayNghi.Value = tv.NGAYNGHI.Value;
                slkNhanVien.EditValue = tv.MANV;
                txtGhiChu.Text = tv.GHICHU;
                txtLyDo.Text = tv.LYDO;
            }
        }

        private void dtNgayNopDon_ValueChanged(object sender, EventArgs e)
        {
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(45);
        }
    }
}