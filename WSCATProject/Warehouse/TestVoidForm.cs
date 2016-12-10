using BaseLayer;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Encrypt;
using InterfaceLayer.Sales;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WSCATProject.Warehouse
{
    public partial class TestVoidForm : Form
    {
        SalesOrderInterface soif = new SalesOrderInterface();
        public TestVoidForm()
        {
            InitializeComponent();
        }

        private void TestVoidForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Show(textBox1);
            //Dictionary<int, string> dc = new Dictionary<int, string>();
            //for (int i = 0; i < 20; i++)
            //{
            //    dc.Add(i,string.Format("{0}",i));
            //}
            //string[] str = new string[3];
            //str[1] = "123";
            //str[2] = "1";

            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("2", "1");
            //hashtable.Add("3", 1);

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("a");
            //arrayList.Add(1);

            //List<string> list = new List<string>();
            //list.Add("a");
            //list.Add(1);
            //Console.WriteLine("123");
            //SqlCommand cmd = new SqlCommand("proc_FVEManagment", DbHelperSQL.Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@code", "asdasd6");  //给输入参数赋值


            //SqlParameter parReturn = new SqlParameter("@return", SqlDbType.Int);
            //parReturn.Direction = ParameterDirection.ReturnValue;   //参数类型为ReturnValue                    
            //cmd.Parameters.Add(parReturn);

            //cmd.ExecuteNonQuery();

            //MessageBox.Show(parReturn.Value.ToString());
        }
        /// <summary>
        /// 统计行数据
        /// </summary>
        private void InitDataGridView()
        {
            //新增一行 用于给客户操作
            sgCustomers.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow gr = (GridRow)sgCustomers.PrimaryGrid.
                Rows[sgCustomers.PrimaryGrid.Rows.Count - 1];
            gr.ReadOnly = true;
            gr.CellStyles.Default.Background.Color1 = Color.SkyBlue;
            gr.Cells["id"].Value = "合计";
            gr.Cells["id"].CellStyles.Default.Alignment =
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["code"].Value = 0;
            gr.Cells["code"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["code"].CellStyles.Default.Background.Color1 = Color.Orange;
            gr.Cells["id"].AllowSelection = false;
            gr.Cells["code"].AllowSelection = false;
            gr.Cells["mainCode"].AllowSelection = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            GridRow gr = (GridRow)sgCustomers.PrimaryGrid.
                Rows[sgCustomers.PrimaryGrid.Rows.Count - 1];
            
            for (int i = 0; i < 20; i++)
            {
                sgCustomers.PrimaryGrid.Rows.Insert(0, new GridRow(i+""+i, i + "" + i, i + "" + i));
            }
            sgCustomers.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            sgCustomers.PrimaryGrid.SortCycle = SortCycle.AscDesc;    //排序方式范围
            sgCustomers.PrimaryGrid.AddSort(sgCustomers.PrimaryGrid.Columns[0], SortDirection.Ascending);//设置排序列和排序方式
            InitDataGridView();
        }
    }
}