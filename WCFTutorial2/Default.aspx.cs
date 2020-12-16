using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFTutorial2.ServiceReference1;

namespace WCFTutorial2
{
    public partial class _Default : Page
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertUser u = new InsertUser();
            u.Name = TextBox1.Text;
            u.Email = TextBox2.Text;
            string r = client.Insert(u);
            lblmsg.Text = r.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.gettesdata g = new ServiceReference1.gettesdata();
            g = client.GetInfo();
            DataTable dt = new DataTable();
            dt = g.usertab;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateUser updated = new UpdateUser();
            updated.UID = int.Parse(txtUserID.Text);
            updated.Name = TextBox1.Text;
            updated.Email = TextBox2.Text;
            string result = client.Update(updated);
            lblmsg.Text = result.ToString();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteUser d = new DeleteUser();
            d.UID = int.Parse(txtUserID.Text);
            string res = client.Delete(d);
            lblmsg.Text = res.ToString();
        }
    }
}