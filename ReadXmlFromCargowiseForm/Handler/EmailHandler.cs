using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlFromCargowiseForm
{
    public class EmailHandler
    {
        EmailService.JsonEmailServiceSoapClient service = new EmailService.JsonEmailServiceSoapClient();
        public void SendEmail(string from, string to, string content)
        {
            var request =new  EmailService.SysSendRequest();
            request.Body = new EmailService.SysSendRequestBody();
            request.Body.From = from;
            request.Body.To= to;
            request.Body.content=content;
            service.SysSend(string.Empty, from, to, string.Empty, string.Empty, "test", content, null, null, null, null, null, null);
        }
    }
}
