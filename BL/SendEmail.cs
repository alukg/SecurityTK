using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class SendEmail
    {
        public static bool Send(string strTo, string strFrom, string strSubject, string strBody)
        {
            bool flag = false;

            MailMessage mailMsg = new MailMessage();

            MailAddress mailAddress = null;

            try

            {
                // To

                mailMsg.To.Add(strTo);
                mailAddress = new MailAddress(strFrom);

                mailMsg.From = mailAddress;
                mailMsg.Subject = strSubject;

                mailMsg.Body = strBody;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;

               /* System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("username", "password");

                smtpClient.Credentials = credentials;
                */

                smtpClient.Send(mailMsg);
                flag = true;

                //MyLogEvent.WriteEntry("Mail Send Successfully");

            }
            catch (Exception ex)

            {

                //MyLogEvent.WriteEntry("Error occured");

               //Response.Write(ex.Message);

            }
            finally

            {
                mailMsg = null;

                mailAddress = null;

            }
            return flag;
        }
    }
}
