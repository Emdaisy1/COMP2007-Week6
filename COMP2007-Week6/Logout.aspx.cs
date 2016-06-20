using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//For Identity & Owin
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP2007_Week6
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Store session info & auth methods in auth manager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //Sign out
            authenticationManager.SignOut();
            //Redirect to default page
            Response.Redirect("~/Login.aspx");
        }
    }
}