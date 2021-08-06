using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Business.Concrete
{

    public class Email_ActivationManager : IEmail_ActivationService
    {
        IEmail_ActivationDal _email_ActivationDal;


        public Email_ActivationManager(IEmail_ActivationDal email_ActivationDal)
        {
            _email_ActivationDal = email_ActivationDal;

        }



        public IDataResult<List<Email_Activation>> GetAll()
        {
            return new SuccessDataResult<List<Email_Activation>>(_email_ActivationDal.GetAll(), "Email listelendi");
        }

        public IDataResult<Email_Activation> GetByCode(string code)
        {
            return new SuccessDataResult<Email_Activation>(_email_ActivationDal.Get(p => p.code == code), "Email Code geldi.");
        }





        public IResult Send(string mail)
        {
            string Code = "";


            {


                string bizimMail = "farketmes321@gmail.com";
                string sifre = "farketmez123";
                bool result = false;

                Random rastgele = new Random();
                string harfler = "ABCDEFGHIJKLMNOPRSTUVYZWX1234567890";
                Code = "";
                for (int i = 0; i < 4; i++)
                {
                    Code += harfler[rastgele.Next(harfler.Length)];
                }

                MailMessage mesaj = new MailMessage(bizimMail, mail, "Onay Kodu", "Üyeliğinizin onaylanması için geçerli onay kodunuz: '" + Code + "'\n\n Uğur Kürekci Ekibi");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(bizimMail, sifre);
                smtp.Send(mesaj);
                result = true;
                if (Code != null)
                {

                    _email_ActivationDal.Add(new Email_Activation { code = Code, email = mail });
                    return new SuccessResult(Code);

                }
            }
            return new SuccessResult();
        }


        public IResult Info(string contact)
        {
            {
                string bizimMail = "farketmes321@gmail.com";
                string sifre = "farketmez123";
                MailMessage mesaj = new MailMessage(bizimMail, contact, "Bizim iletişim kurduğunuz için teşekkürler.", "Yakın zaman içerisinde mesajınıza geri dönüş sağlanacaktır. '" + contact + "'\n\n Uğur Kürekci Ekibi");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(bizimMail, sifre);
                smtp.Send(mesaj);
                if (contact != null)
                {

                    _email_ActivationDal.Add(new Email_Activation { email = contact });
                    return new SuccessResult();

                }
            }
            return new SuccessResult();
        }
    }
}