using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductionControl
{
    class SMTPMailer
    {
        // Input Parameters
        private MailMessage _myMessage = new MailMessage();
        private SmtpClient _mySMTPClient = new SmtpClient();

        public String EmailFrom { get; set; }
        public List<string> EmailTo { get; set; } = new List<string>();
        public List<string> EmailCC { get; set; } = new List<string>();
        public List<string> EmailBcc { get; set; } = new List<string>();
        public string EmailSubject { get; set; }
        public string EmailBodyText { get; set; }
        public List<string> EmailAttachmentName { get; set; } = new List<string>();
        public string ErrorMessage { get; set; }
        public String SMTPHost { get; set; }
        public Int32 SMTPPort { get; set; }
        public String SMTPUserName { get; set; }
        public String SMTPPassword { get; set; }

        public Boolean Send_Email_Message(Boolean isHTML)
        {
            Boolean isSuccesful = true;

            ErrorMessage = string.Empty;

            try
            {
                Configure_Mailer();
                Compose_Mail_Message(isHTML);
                _mySMTPClient.Send(_myMessage);
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                isSuccesful = false;
            }

            _myMessage.Dispose();

            return isSuccesful;
        }

        private void Compose_Mail_Message(Boolean isHTML)
        {
            Attachment myAttachment;
            int i = 0;

            _myMessage.Subject = EmailSubject;
            _myMessage.Body = EmailBodyText;
            _myMessage.IsBodyHtml = isHTML;

            System.Net.Mail.MailAddress fromAddress = new MailAddress(EmailFrom);
            _myMessage.From = fromAddress;
            for (i = 0; i < EmailTo.Count; i++)
                _myMessage.To.Add(EmailTo[i]);
            for (i = 0; i < EmailCC.Count; i++)
                _myMessage.CC.Add(EmailCC[i]);
            for (i = 0; i < EmailBcc.Count; i++)
                _myMessage.Bcc.Add(EmailBcc[i]);

            foreach (string strAttachment in EmailAttachmentName)
            {
                myAttachment = new Attachment(strAttachment);
                _myMessage.Attachments.Add(myAttachment);
            }

        }
        public void Configure_Mailer()
        {
            _mySMTPClient.Port = SMTPPort;
            _mySMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _mySMTPClient.Host = SMTPHost;
            _mySMTPClient.UseDefaultCredentials = false;
        }
    }
}

