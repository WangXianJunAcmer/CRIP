using CRIP.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CRIP.ResourceParameters
{
    [RegisterValidation]
    public class RegisterParameter
    {
        [ServiceStack.DataAnnotations.Unique]
        [Required(ErrorMessage = "用戶名不能为空")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "账号不能为空")]
        [EmailAddress(ErrorMessage = "不是邮箱格式")]
        public string Email { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "确认密码与密码不相同")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "验证码不能为空")]
        public string Code { get; set; }   //验证码
    }
}
