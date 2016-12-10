using HelperUtility.Encrypt;
using InterfaceLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject.Warehouse
{
    public partial class WareHuseStorageRack : Form
    {
        CodingHelper ch = new CodingHelper();
        public WareHuseStorageRack()
        {
            InitializeComponent();
        }

        #region  绑定数据到下拉框

        private void WareHuseStorageRack_Load(object sender, EventArgs e)
        {
            cboQuYu.SelectedIndex = 0;
            cboHuoJia.SelectedIndex = 0;
            cboPai.SelectedIndex = 0;
           cboLie.SelectedIndex = 0;
            //绑定仓库下拉框
            StorageInterface sif = new StorageInterface();
            DataTable dt = ch.DataTableReCoding(sif.GetList(999,""));
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            cboCangKu.DisplayMember = "name";
            cboCangKu.ValueMember = "code";
            cboCangKu.DataSource = dt;
        }

        private void cboCangKu_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCangKu.SelectedValue == null || cboCangKu.Text=="请选择")
            {
                cboQuYu.DataSource = null;
                return;
            }
            //根据仓库code绑定货架下拉框
            StorageRackInterface srif = new StorageRackInterface();
            DataTable dt = ch.DataTableReCoding(srif.SelStorageRackByCode(XYEEncoding.strCodeHex(cboCangKu.SelectedValue.ToString())));
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            cboQuYu.DisplayMember = "name";
            cboQuYu.ValueMember = "code";
            cboQuYu.DataSource = dt;
        }

        private void cboQuYu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuYu.SelectedValue == null || cboQuYu.Text == "请选择")
            {
                cboHuoJia.DataSource = null;
                return;
            }
            //根据货架code绑定排的下拉框
            StorageRackInterface srif = new StorageRackInterface();
            DataTable dt = ch.DataTableReCoding(srif.SelStorageRackByCode(XYEEncoding.strCodeHex(cboQuYu.SelectedValue.ToString())));
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            cboHuoJia.DisplayMember = "name";
            cboHuoJia.ValueMember = "code";
            cboHuoJia.DataSource = dt;
        }

        private void cboHuoJia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboHuoJia.SelectedValue == null || cboHuoJia.Text == "请选择")
            {
                cboPai.DataSource = null;
                return;
            }
            //根据排的code绑定格的下拉框
            StorageRackInterface srif = new StorageRackInterface();
            DataTable dt = ch.DataTableReCoding(srif.SelStorageRackByCode(XYEEncoding.strCodeHex(cboHuoJia.SelectedValue.ToString())));
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            cboPai.DisplayMember = "name";
            cboPai.ValueMember = "code";
            cboPai.DataSource = dt;
        }

        private void cboPai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPai.SelectedValue == null || cboPai.Text == "请选择")
            {
               cboLie.DataSource = null;
                return;
            }
            //根据排的code绑定格的下拉框
            StorageRackInterface srif = new StorageRackInterface();
            DataTable dt = ch.DataTableReCoding(srif.SelStorageRackByCode(XYEEncoding.strCodeHex(cboPai.SelectedValue.ToString())));
            DataRow dr = dt.NewRow();
            dr["name"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

           cboLie.DisplayMember = "name";
           cboLie.ValueMember = "code";
           cboLie.DataSource = dt;
        }
        #endregion

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueDing_Click(object sender, EventArgs e)
        {
            WareHouseInMain whi = (WareHouseInMain)this.Owner;
            if (checkBoxX1.Checked == false || cboQuYu.Text == "请选择")
            {
                if (MessageBox.Show(Owner, "是否临时存放", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    //是临时存放
                    whi.StorageCode = cboCangKu.SelectedValue == null ? "" : cboCangKu.SelectedValue.ToString();
                    whi.Storage ="临时存放地";
                    whi.StorageQuyu = "临时存放地";
                    Close();
                    Dispose();
                    return;
                }
                else
                {
                    //不是临时存放
                    whi.StorageCode = cboCangKu.SelectedValue == null ? "" : cboCangKu.SelectedValue.ToString();
                    whi.Storage = cboCangKu.Text;
                    whi.StorageQuyuCode = cboQuYu.SelectedValue == null ? "" : cboQuYu.SelectedValue.ToString();
                    whi.StorageQuyu = cboQuYu.Text;
                    whi.StorageRackCode = cboHuoJia.SelectedValue == null ? "" : cboHuoJia.SelectedValue.ToString();
                    whi.StorageRack = cboHuoJia.Text;
                    whi.StoragePaiCode = cboPai.SelectedValue == null ? "" : cboPai.SelectedValue.ToString();
                    whi.StoragePai = cboPai.Text;
                    whi.StorageGeCode =cboLie.SelectedValue == null ? "" :cboLie.SelectedValue.ToString();
                    whi.StorageGe =cboLie.Text;
                    Close();
                    Dispose();
                    return;
                }
            }
            whi.StorageCode = cboCangKu.SelectedValue == null ? "" : cboCangKu.SelectedValue.ToString();
            whi.Storage = cboCangKu.Text;
            whi.StorageQuyuCode = cboQuYu.SelectedValue == null ? "" : cboQuYu.SelectedValue.ToString();
            whi.StorageQuyu = cboQuYu.Text;
            whi.StorageRackCode = cboHuoJia.SelectedValue == null ? "" : cboHuoJia.SelectedValue.ToString();
            whi.StorageRack = cboHuoJia.Text;
            whi.StoragePaiCode = cboPai.SelectedValue == null ? "" : cboPai.SelectedValue.ToString();
            whi.StoragePai = cboPai.Text;
            whi.StorageGeCode =cboLie.SelectedValue == null ? "" :cboLie.SelectedValue.ToString();
            whi.StorageGe =cboLie.Text;
            Close();
            Dispose();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void WareHuseStorageRack_Activated(object sender, EventArgs e)
        {
            cboCangKu.Focus();
        }
    }
}
