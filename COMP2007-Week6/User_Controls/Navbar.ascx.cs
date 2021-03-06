﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//For Identity & Owin
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/*
 * @Author: Emma Hilborn - 200282755
 */

namespace COMP2007_Week6
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                    if(HttpContext.Current.User.Identity.GetUserName() == "Emma")
                    {
                        UserPlaceHolder.Visible = true;
                    }
                }
                else
                {
                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                    UserPlaceHolder.Visible = false;
                }
                SetActivePage();
            }

        }


        /**
         * This method adds the "active" CSS class to the list items
         * on the nav bar on each page
         * 
         * @method SetActivePage
         * @return (void)
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
                case "Contoso Menu":
                    menu.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Users":
                    users.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}