using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class New_Asset : System.Web.UI.Page
    {
        //Connection String
        string str = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;
        public void InsertAsset()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {

                    DateTime localDateTime, univDateTime;

                    string dateTime = TextBox1.Text;
                    localDateTime = DateTime.Parse(dateTime);
                    univDateTime = localDateTime.ToLocalTime();
                    Response.Write(localDateTime);
                    con.Open();


                    //DateTime d = DateTime.ParseExact(Convert.ToString(TextBox1.Text),"DD:MM:YYYY", new System.Globalization.CultureInfo("en-IN")); Convert.ToDateTime(d)

                    SqlCommand cmd = new SqlCommand("insert into Asset values('" + TextBoxAssetName.Text + "','" + DropDownListVendorName.Text + "','" + univDateTime + "','" + Convert.ToInt32(TextBoxCost1.Text) + "')", con);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                    Clear();                            
                        
                }
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Plz fill all fields')</script>"+e.Message.ToString());
                Clear();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // disable future date
            TextBox1_CalendarExtender.EndDate = DateTime.Now;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select VendorName from Vendor1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownListVendorName.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    
                }
            }
        }
       // this function insert the new record in asset table
        protected void ButtonAddAsset_Click(object sender, EventArgs e)
        {
            InsertAsset();
        }
        public void Clear()
        {
            TextBoxAssetName.Text = "";
            //DropDownListVendorName.Items.Clear();
            TextBox1.Text = "";
            TextBoxCost1.Text = "";
        }
    }
}