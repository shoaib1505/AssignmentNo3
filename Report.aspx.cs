using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class Report : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString; //Connection String 
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            CostCalc();
            Label3.Text = GridView1.Rows.Count.ToString() + "  :  " + "No. of Records found";
                if(GridView1.Rows.Count ==0)
            {
                Label1.Visible = false;
                Label2.Visible = false;
            }
        }
        //Filling the gridView fields From Database
        private void BindGrid() 
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Id, AssetName, VendorName, PurchaseDate, Cost from Asset", con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();

                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label3.Text = GridView1.Rows.Count.ToString() + "  :  " + "No. of Records found";
                CostCalc();
            }
        }
        //Total Number Of Sale dispaly in Label
        void CostCalc() 
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select sum(Cost) as total from Asset", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();       
            }
        }
        //search Field For AssetNAME AND venodr Name 
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Id,AssetName,VendorName,PurchaseDate,Cost from Asset where AssetName  like '" + txtreportsearch.Text + "%' or VendorName Like '" + txtreportsearch.Text + "%' ", con);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();
                    Label3.Text = GridView1.Rows.Count.ToString() + "  :  " + "No. of Records found";
                    CostCalc();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}