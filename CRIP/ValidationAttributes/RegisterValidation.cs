using CRIP.ResourceParameters;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CRIP.ValidationAttributes
{
    public class RegisterValidation:ValidationAttribute //继承验证类
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var registerParameter = (RegisterParameter)validationContext.ObjectInstance;

            //使用regex进行格式设置 至少有数字、大小写字母，最少8个字符、最长30个字符
            Regex regex = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,30}");

            if (!regex.IsMatch(registerParameter.Password))//判断密码格式是否符合要求
            {
                return new ValidationResult(
                    "密码至少有数字、大小写字母，最少8个字符、最长30个字符",
                    new[] { "注册格式" }
                    );
            }
            return ValidationResult.Success;
        }
    }
}
