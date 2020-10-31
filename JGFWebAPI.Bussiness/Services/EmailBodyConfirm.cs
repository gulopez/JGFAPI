using JGFWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JGFWebAPI.Bussiness.Services
{
    public class EmailBodyConfirm
    {
        public string MessageBodyConfirm(UsuarioViewModel vm)
        {
            string body = String.Empty;
            body =  "<h1 style='margin - left: 15 %; '>" +
                        "Colegio Jose Gil Fortoul" +
                    "</h1>" +
                    "<br />" +
                    "<p style = 'padding: 10px;' > Muchas gracias por registrarse en nuestro sistema.</p>";

            return body;
        }
    }
}
