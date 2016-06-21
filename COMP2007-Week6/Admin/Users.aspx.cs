using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for EF access
using COMP2007_Week6.Models;
using System.Web.ModelBinding;

namespace COMP2007_Week6.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUsers();
            }
        }

        protected void GetUsers()
        {
            using (UserConnection db = new UserConnection())
            {
                var Users = (from users in db.AspNetUsers
                             select users);
                UsersGridView.DataSource = Users.ToList();
                UsersGridView.DataBind();
            }
        }

        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;

            string UserID = UsersGridView.DataKeys[selectedRow].Values["Id"].ToString();
        }
    }
}