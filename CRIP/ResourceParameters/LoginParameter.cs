using System.ComponentModel.DataAnnotations;

namespace CRIP.ResourceParameters
{
    public class LoginParameter
    {
        [Required(ErrorMessage = "账号不能为空")]
        [EmailAddress(ErrorMessage = "不是邮箱格式")]
        public string Email { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

    }
}
