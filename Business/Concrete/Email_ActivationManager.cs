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

        public IResult Add(Email_Activation email_Activation)
        {
            _email_ActivationDal.Add(email_Activation);
            return new SuccessResult("Email eklendi.");
        }

        public IResult Send(string mail)
        {
            string Code = "";

            {
                bool result = false;

                string bizimMail = "*****s321@gmail.com";
                string sifre = "********z123";

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
    }
}