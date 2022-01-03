using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace Assignment3
{
    public partial class AssetList : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString; // Connection String

        //Filling the dropdown List 
        public void dp()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                TextBox1.Enabled = false;
                TextBoxEditAssetId.Enabled = false;
                BindGrid();
                dp();
                if(GridView1.Rows.Count == 0 )
                {
                    Panel3.Visible = false;

                }
            }
            Label11.Text = GridView1.Rows.Count.ToString() + " : " + "NO. of Records Found";

        }
        //display Gird from Database
        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Id, AssetName, VendorName, Cost from Asset", con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                
                DataTable dt = new DataTable();

                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label11.Text = GridView1.Rows.Count.ToString() + " : " + "NO. of Records Found";






            }
        }

        //this method is use to insert the value in the grid using model popup window 
        protected void Button3_Click(object sender, EventArgs e)
        {
            /*DateTime d = DateTime.ParseExact(Convert.ToString(TextBox4.Text), "dd/MM/yyyy", null);
            
            d = Convert.ToDateTime(d, CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);*/
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    
                   
                    SqlCommand cmd = new SqlCommand("insert into Asset values ('" + TextBox2.Text + "', '" + DropDownList2.Text + "','" + Convert.ToDateTime(TextBox4.Text)+ "' , '" + Convert.ToInt32(TextBox5.Text) + "')", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Data has Been Inserted')</script>");
                    BindGrid();
                }
            }
            catch (Exception e1)
            {
                Response.Write("<script>alert('Plz fill all fields')</script>"+e1.Message.ToString());
            }
        }

        //this Function is used to delete a selected row in grid view 
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Asset where Id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
                cmd.ExecuteNonQuery();
               

                BindGrid();
                if (GridView1.Rows.Count == 0)
                {
                    Panel3.Visible = false;
                }
                else
                {
                    Panel3.Visible = false; 
                }
               Response.Redirect(Request.Url.ToString());
            }
        }


        //Filling the Updated Grid 
        void AssetListGrid() 
        {
          //  Panel3.Visible = true;
            using (SqlConnection connect = new SqlConnection(str))
            {
                connect.Open();
                SqlCommand sqlcom = new SqlCommand("select * from Asset", connect);
                SqlDataReader dr = sqlcom.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
            }
        }

        // Filling the DropDown List box from Database
        public void EditDropDown() 
        {
          //  Panel3.Visible = true;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownListEditVendorAsset.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
        }
        //This Method Return The selected Valuein the model popup Field
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel3.Visible = true;
            DropDownListEditVendorAsset.Items.Clear();
            TextBoxEditAssetId.Text = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select AssetName, VendorName, PurchaseDate, Cost from Asset where Id='" + TextBoxEditAssetId.Text + "'");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    TextBoxEditAssetName.Text = dr["AssetName"].ToString();
                    DropDownListEditVendorAsset.Items.Insert(0, new ListItem(dr["VendorName"].ToString()));
                    EditDropDown();
                    TextBoxEditPurchase.Text = dr["PurchaseDate"].ToString();
                    TextBoxEditCost.Text = dr["Cost"].ToString();
                }
            }
            /*TextBoxEditAssetName.Text = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            DropDownListEditVendorAsset.Items.Insert(0, new ListItem(GridView1.Rows[e.NewSelectedIndex].Cells[2].Text));
            EditDropDown();
            TextBoxEditCost.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;*/
        }

        // Updating The Selected Row 
        protected void ButtonEditAsset_Click(object sender, EventArgs e) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {


                    DateTime localDateTime, univDateTime;

                    string dateTime = TextBoxEditPurchase.Text;
                    localDateTime = DateTime.Parse(dateTime);
                    univDateTime = localDateTime.ToLocalTime();

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Asset set AssetName='" + TextBoxEditAssetName.Text + "',VendorName='" + DropDownListEditVendorAsset.Text + "', PurchaseDate = '"+ univDateTime + "',Cost='" + Convert.ToDecimal(TextBoxEditCost.Text) + "' where Id='" + Convert.ToInt32(TextBoxEditAssetId.Text) + "'", con);
                    cmd.ExecuteNonQuery();
                    Panel3.Visible = true;
               }          
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Plz fill all fields')</script>");
            }
            BindGrid();
            Clear();
        }
        // Clear All The Field in Model pop up
        public void Clear() 
        {
            TextBoxEditAssetId.Text = "";
            TextBoxEditAssetName.Text = "";
            DropDownListEditVendorAsset.Items.Clear();
            TextBoxEditCost.Text = "";
        }
        //Cancel Button for Model pop up
        protected void ButtonCancelEdit_Click(object sender, EventArgs e)
        {
            Clear();
            Panel3.Visible = false;
        }

        //Seatch box for AssetList Check Only Asset Name And Vendor Name
        protected void txtsearch_TextChanged(object sender, EventArgs e) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select Id,AssetName,VendorName,PurchaseDate,Cost from Asset where AssetName  like '" + txtsearch.Text + "%' OR VendorName Like '" + txtsearch.Text + "%' ", con);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();
                    Label11.Text = GridView1.Rows.Count.ToString() + " : " + "NO. of Records Found";
                    Panel3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}