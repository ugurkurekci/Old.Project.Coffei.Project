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

    public class Email_ActivationService : IEmail_ActivationService
    {
        readonly IEmail_ActivationDal _email_ActivationDal;


        public Email_ActivationService(IEmail_ActivationDal email_ActivationDal)
        {
            _email_ActivationDal = email_ActivationDal;

        }



        public IDataResult<List<Email_Activation>> getAll()
        {
            return new SuccessDataResult<List<Email_Activation>>(_email_ActivationDal.GetAll(), "Email listelendi");
        }

        public IDataResult<Email_Activation> getByCode(string code)
        {
            return new SuccessDataResult<Email_Activation>(_email_ActivationDal.Get(p => p.code == code), "Email Code geldi.");
        }





        public IResult Send(string mail)
        {
            {


                string bizimMail = "*****s321@gmail.com";
                string sifre = "******z123";
                Random rastgele = new Random();
                string harfler = "ABCDEFGHIJKLMNOPRSTUVYZWX1234567890";
                string Code = "";
                for (int i = 0; i < 4; i++)
                {
                    Code += harfler[rastgele.Next(harfler.Length)];
                }

                MailMessage mesaj = new MailMessage(bizimMail, mail, "Onay Kodu", "Üyeliğinizin onaylanması için geçerli onay kodunuz: '" + Code + "'\n\n Uğur Kürekci Ekibi");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(bizimMail, sifre)
                };
                smtp.Send(mesaj);
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
                string bizimMail = "*****s321@gmail.com";
                string sifre = "******z123";
                MailMessage mesaj = new MailMessage(bizimMail, contact, "Bizim iletişim kurduğunuz için teşekkürler.", "Yakın zaman içerisinde mesajınıza geri dönüş sağlanacaktır. '" + contact + "'\n\n Uğur Kürekci Ekibi");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(bizimMail, sifre)
                };
                smtp.Send(mesaj);
                if (contact != null)
                {

                    _email_ActivationDal.Add(new Email_Activation { email = contact });
                    return new SuccessResult();

                }
            }
            return new SuccessResult();
        }
        public static class SendMail
        {
            public static bool Send(string GMailHesabi, string GMailHesapSifresi, string GMailUnvan, string AMailHesabi, string MailKonu, string MailIcerik, string Pop3Host, int Pop3Port)
            {
                try
                {
                    ICredentials cred = new NetworkCredential(GMailHesabi, GMailHesapSifresi);
                    // mail göndermek için oturum açtık

                    using (MailMessage mail = new MailMessage())// yeni mail oluşturduk
                    {
                        mail.From = new MailAddress(GMailHesabi, GMailUnvan); // maili gönderecek hesabı belirttik
                        mail.To.Add(AMailHesabi); // mail gönderilecek adres
                        mail.Subject = MailKonu; // mailin konusu
                        mail.Body = MailIcerik; // mailin içeriği
                                                // göndereceğimiz maili hazırladık.

                        using SmtpClient smtp = new SmtpClient(Pop3Host, Pop3Port); // smtp servere bağlandık
                        smtp.UseDefaultCredentials = false; // varsayılan girişi kullanmadık
                        smtp.EnableSsl = true; // ssl kullanımına izin verdik
                        smtp.Credentials = (NetworkCredential)cred; // server üzerindeki oturumumuzu yukarıda belirttiğimiz NetworkCredential üzerinden sağladık.
                        smtp.Send(mail); // mailimizi gönderdik.
                                         // smtp yani Simple Mail Transfer Protocol üzerinden maili gönderiyoruz.

                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
