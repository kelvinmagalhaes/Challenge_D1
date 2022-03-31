using Challenge_D1.DAL;
using Challenge_D1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Challenge_D1.DAL.CustomerContext;

namespace Challenge_D1.DAL
{
    public class ClientsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<CustomerContext>
        {
            protected override void Seed(CustomerContext context)
            {
                var customer = new List<Customer>
            {
            new Customer{Name="Kelvin",Date="1994-03-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Antônio",Date="1999-05-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Jorge",Date="1992-02-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Eduardo",Date="1991-01-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Rafael",Date="1992-03-15", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Alisson",Date="1995-07-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            new Customer{Name="Pedro",Date="1997-08-10", RG = "", CPF = "331.674.156-90", Cel = "+550099999999" , Fone = "+550088888888",OtherPhone = "", Address = "Rua: José de Almeira, N* 255", OtherAddress = "", LinkFacebook = "https://www.facebook.com/Kelvin", LinkLinkedin =  "https://www.linkedin.com/in/Kelvin", LinkTwitter = "https://www.Twitter.com/in/Kelvin", LinkInstagram = "https://www.Instagram.com/in/Kelvin"},
            };
                customer.ForEach(s => context.Customers.Add(s));
                context.SaveChanges();
            }
        }
}