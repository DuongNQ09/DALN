using DevExpress.XtraEditors;
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
    public partial class frmQuanLyLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyLuong()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD;
        NHANVIEN_NANGLUONG _nvnl;
        HOPDONGLAODONG _hopdong;
        NHANVIEN _nv;

        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            _nvnl = new NHANVIEN_NANGLUONG();
            _hopdong = new HOPDONGLAODONG();
            _nv = new NHANVIEN();
            _them = false;
            loadData();
            loadHopDong();
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
            txtGhiChu.Enabled = !kt;
            slkHopDong.Enabled = !kt;
            dtNgayNangLuong.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _nvnl.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadHopDong()
        {
            slkHopDong.Properties.DataSource = _hopdong.getListFull();
            slkHopDong.Properties.ValueMember = "SOHD";
            slkHopDong.Properties.DisplayMember = "SOHD";
        }
        void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dtNgayKy.Value = DateTime.Now;
            dtNgayNangLuong.Value = dtNgayKy.Value.AddDays(45);
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
                _nvnl.Delete(_soQD, 1);
                var hd = _hopdong.getItem(slkHopDong.EditValue.ToString());
                hd.HESOLUONG = double.Parse(spHSLCu.EditValue.ToString());
                _hopdong.Update(hd);
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
            tb_NHANVIEN_NANGLUONG nl;
            if (_them)
            {
                var maxSoQD = _nvnl.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;

                nl = new tb_NHANVIEN_NANGLUONG();
                nl.SOQD = so.ToString("00000") + @"/" + DateTime.Now.Year.ToString() + @"/QĐNL";
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayNangLuong.Value;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse(spHSLMoi.EditValue.ToString());
                nl.GHICHU = txtGhiChu.Text;
                nl.MANV = _hopdong.getItem(slkHopDong.EditValue.ToString()).MANV;
                nl.CREATED_BY = 1;
                nl.CREATED_DATE = DateTime.Now;
                _nvnl.Add(nl);
            }
            else
            {
                nl = _nvnl.getItem(_soQD);
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayNangLuong.Value;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse(spHSLMoi.EditValue.ToString());
                nl.GHICHU = txtGhiChu.Text;
                nl.MANV = _hopdong.getItem(slkHopDong.EditValue.ToString()).MANV;
                nl.UPDATED_BY = 1;
                nl.UPDATED_DATE = DateTime.Now;
                _nvnl.Update(nl);
            }
            var hd = _hopdong.getItem(slkHopDong.EditValue.ToString());
            hd.HESOLUONG = double.Parse(spHSLMoi.EditValue.ToString());
            _hopdong.Update(hd);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var nl = _nvnl.getItem(_soQD);
                txtSoQD.Text = _soQD;
                dtNgayKy.Value = nl.NGAYKY.Value;
                dtNgayNangLuong.Value = nl.NGAYLENLUONG.Value;
                slkHopDong.EditValue = nl.SOHD;
                txtGhiChu.Text = nl.GHICHU;
                spHSLCu.EditValue = nl.HESOLUONGHIENTAI;
                spHSLMoi.EditValue = nl.HESOLUONGMOI;
                txtNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();
            }
        }

        private void slkHopDong_EditValueChanged(object sender, EventArgs e)
        {
            var hd = _hopdong.getItemFull(slkHopDong.EditValue.ToString());
            if (hd.Count!=0)
            {
                txtNhanVien.Text = hd[0].MANV + " - " + hd[0].HOTEN;
                spHSLCu.EditValue = hd[0].HESOLUONG;

            }
        }

    }
}