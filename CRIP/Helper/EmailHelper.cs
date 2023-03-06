using System.Net;
using System.Net.Mail;

namespace CRIP.Helper
{
    public class EmailHelper
    {
        private static MailMessage _mailMessage;

        /// <summary>
        /// 发送的信息，发送的默认地址，如果传参了话就被覆盖
        /// </summary>
        /// <param name="msg">发送的信息</param>
        /// <param name="address">发送的地址</param>
        /// <returns></returns>

        public static async Task<bool> SendEmail()
        {
           
            //实例化一个SmtpClient类
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送
            client.UseDefaultCredentials = false;
            //验证发件人身份（发件人的邮箱，这里第二个参数就是生成授权码）
            client.Credentials = new NetworkCredential("3125156343@qq.com", "fartajeuitjrddhg");
            //发送
            try
            {
                await client.SendMailAsync(_mailMessage);
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
          
            return true;
        }
        public static void SetMessage(string subject,string body,string address)
        {

            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();

            //发件人邮箱地址
            mailMessage.From = new MailAddress("3125156343@qq.com");
            //收件人邮箱地址
            mailMessage.To.Add(new MailAddress(address));
            //邮件的标题
            mailMessage.Subject = subject;
            //邮件内容
            mailMessage.Body = body;
            //设置MailMessage类
            _mailMessage = mailMessage;
        }

    }

}
