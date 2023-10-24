﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controlador;
using dominio;

namespace Catálogo_Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgLogo.ImageUrl = "https://png.pngtree.com/png-vector/20190802/ourlarge/pngtree-cart-icon-design-vector-png-image_1644380.jpg";
            ImgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is Registro || Page is Default))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblUser.Text = user.Email;
                    if ( !string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        ImgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}