using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        private SqlConnection conn = new SqlConnection("Server=DESKTOP-2QKN505\\SQLEXPRESS; Database=Northwind; Integrated Security=true;");


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            DataTable dt = new DataTable();
            string query = "select * from ProCat";
            if (TxtInput.Text != "")
            {
                query += " where CategoryName = '" + TxtInput.Text + "';";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                LblNotFound.Text = "";
                if(dt.Rows.Count == 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    LblNotFound.Text = "Result is not found";
                    conn.Close();
                    return;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                conn.Close();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                LblNotFound.Text = "Result is not found";
            }
        }
    }
}