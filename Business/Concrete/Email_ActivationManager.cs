using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IResult Add(Email_Activation email_Activation, string mail)
        {
            string _OnayKodu = "";
           
            {
                bool sonuc = false;

                string bizimMail = "**s321@gmail.com";
                string sifre = "**123";

                Random rastgele = new Random();
                string harfler = "ABCDEFGHIJKLMNOPRSTUVYZWX";
                _OnayKodu = "";
                for (int i = 0; i < 6; i++)
                {
                    _OnayKodu += harfler[rastgele.Next(harfler.Length)];
                }
                try
                {
                    MailMessage mesaj = new MailMessage(bizimMail, mail, "Onay Kodu", "Üyeliğinizin onalanması için geçerli onay kodunuz: '" + _OnayKodu + "'\n\n Uğur Kürekci Ekibi");
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(bizimMail, sifre);
                    smtp.Send(mesaj);
                    sonuc = true;
                }
                catch (Exception ex)
                {
                    return new ErrorResult("Onay Kodu Gönderiminde Hata: " + ex.Message);
                }
               
            }

            _email_ActivationDal.Add(email_Activation);
            return new SuccessResult("Email eklendi.");
        }


    }
}