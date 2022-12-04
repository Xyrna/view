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
        bool TextChanged = false;

        private SqlConnection conn = new SqlConnection("Server=DESKTOP-2QKN505\\SQLEXPRESS; Database=Northwind; Integrated Security=true;");


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextChanged)
            {
                //string a = TxtInput.Text;
                Session["data"] = null;
            }
           BindMethod();
           TextChanged = false;
            
        }

        private void BindMethod()
        {
            if (Session["data"] == null)
            {


                conn.Open();
                DataSet ds = new DataSet();
                string query = "select * from ProCat";
                if (TxtInput.Text != "")
                {
                    query += " where CategoryName = '" + TxtInput.Text + "';";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    LblNotFound.Text = "";

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();

                        conn.Close();
                        LblNotFound.Text = "Result is not found!";
                        return;
                    }
                    Session["data"] = ds.Tables[0].DefaultView;
                    conn.Close();
                }

            }
            if(Session["data"] == null)
            {

            LblNotFound.Text = "Result is not found!";
            GridView1.DataSource = null;
            GridView1.DataBind();
            } else
            {
                GridView1.DataSource = Session["data"];
                GridView1.DataBind();
                LblNotFound.Text = "";
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindMethod();
        }

        protected void TxtInput_TextChanged(object sender, EventArgs e)
        {
            TextChanged = true;
        }
    }
}