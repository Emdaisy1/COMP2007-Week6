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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //Create new userStore & userManager - container to manage users in DB
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //Search for and create user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            //If match found, log in
            if(user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in
                //Sign in
                authenticationManager.SignIn(new AuthenticationProperties() {IsPersistent = false }, userIdentity);

                //Redirect to main menu
                Response.Redirect("~/Contoso/MainMenu.aspx");
            }
            else
            {
                //Throw error to alert flash
                StatusLabel.Text = "Invalid username or password!";
                AlertFlash.Visible = true;
            }
        }
    }
}