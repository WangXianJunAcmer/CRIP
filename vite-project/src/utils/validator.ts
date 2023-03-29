// 验证邮箱
export function isEmail(path: string): boolean {
  return /^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$/.test(
    path
  );
}

// 验证手机
export function isPhone(tel: string): boolean {
  return /^[1][3,4,5,6,7,8,9][0-9]{9}$/.test(tel);
}
