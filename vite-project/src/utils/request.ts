//对于axios进行二次封装
import axios, { Axios, AxiosRequestConfig } from 'axios'

import { ElMessage } from 'element-plus';
import { useTestStore } from '../store';


import 'element-plus/es/components/message/style/css'

const request = axios.create({
    //配置对象
    // baseURL: import.meta.env.VITE_API_BASEURL
    // baseURL: '/auth'
  })
  // 请求拦截器an
request.interceptors.request.use(function (config) {
    //统一设置用户身份token
  


  

  
    return config;
  }, function (error) {
  
    // if(error.status==500)
    ElMessage.error("请求失败")
  
    // Do something with request error
    return Promise.reject(error);
  });
  
  // 相应拦截器
  request.interceptors.response.use(function (response) {
    //统一处理接口响应错误，比如token过期无效，服务端异常
  
  

    ElMessage({
      message: response.data.msg,
      type: 'success',
    })
  
  
    if (response.data.data.role && response.data.data.token) {
      const role = response.data.data.role
      const tokenmessage = response.data.data.token
  
      const UseName = useTestStore()
  
      UseName.setName(role, tokenmessage)
      

    }

      //处理userMessage
if (response.data.data.userMessage && response.data.data.userMessage.userName) {
  const userName = response.data.data.userMessage.userName
  const store = useTestStore()
 console.log("xingmaaaaaaaaaaa",userName)
  store.setUSERmessage(userName)
  console.log(store.username)
}
   
  
   
  
  
  
  
    return response;
  }, function (error) {
  
  

    if (error.response.data.code == 400 || error.response.data.code == 401)
    ElMessage.error(error.response.data.error)
  else
    if (error.response.status == 500)
      ElMessage.error("服务器异常")
    else
      if (error.response.data.code == 404)
        ElMessage.error(error.response.data.error)
      else
        ElMessage.error("异常")




  return Promise.reject(error);
  
  });

  export default request