//对于axios进行二次封装
import axios, { Axios, AxiosRequestConfig } from 'axios'

import { ElMessage, Message } from 'element-plus';


import 'element-plus/es/components/message/style/css'
import { json } from 'stream/consumers';
import { useTestStore } from '../store';
// import  {  AxiosResponseHeaders}  from './../api/types/common'

// 创建实例
const requestArea = axios.create({
  //配置对象
  // baseURL: import.meta.env.VITE_API_BASEURL
  // baseURL: '/auth'
})
// 请求拦截器an
requestArea.interceptors.request.use(function (config) {


  return config;
}, function (error) {

  // if(error.status==500)
  ElMessage.error("请求失败")

  // Do something with request error
  return Promise.reject(error);
});

// 相应拦截器
requestArea.interceptors.response.use(function (response) {
  //统一处理接口响应错误，比如token过期无效，服务端异常



  // ElMessage({
  //   message: response.data.msg,
  //   type: 'success',
  // })
  // //处理role
  // if (response.data.data.role && response.data.data.token) {
  //   const role = response.data.data.role
  //   const tokenmessage = response.data.data.token
  //   const UseName = useTestStore()
  //   UseName.setName(role, tokenmessage)
  // }
  // response.config.

  let semm: string = response.headers['x-pagination']


  // console.log(JSON.parse(semm))
  // console.log("'x-pagination:'"+response.headers['x-pagination'])

  // {
  //   previousPageLink:string,

  //   nextPageLink:string,
  //   totalCount:string,
  //   pageSize:number,
  //   currentPage:number,
  //   totalPages:number
  // }

  response.headers



  return response;
}, function (error) {


  if (error.response.data.code == 400 || error.response.data.code == 401)
    ElMessage.error(error.response.data.error)
  else
    if (error.response.status == 500)
      ElMessage.error("服务器异常")
  // else
  //   if (error.response.data.code == 404)
  //     ElMessage.error(error.response.data.error)
  // else
  //   ElMessage.error("异常")




  return Promise.reject(error);

});
export default <T = any>(config: AxiosRequestConfig) => {

  return requestArea(config)
    .then(res => {

      let { headers, data: { data: { goodss } } } = res

      let hd = { headers, goodss }
      console.log(hd)

      return hd
    })





};







