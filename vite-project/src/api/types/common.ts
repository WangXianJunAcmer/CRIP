import request from "../../utils/request";


//发送验证码业务
export const postToRegister=async (
    data:{

        email:string
    }
)=>{
    const res = await request.post<ResponseData>(
        `/api/user/${data.email}/Register`,
        data
    );
    return res.data;
   
}
 //注册
 export const  Register =async (
    data:{
        username:string
        email:string
        password:string
        confirmPassword:string
        code:string
    }

)=>{

    const res = await request.post<ResponseData>(
        '/api/user/register',
        data

    );
    return res.data;

}



 //登录业务
 interface ResponseData<T=any>{
  
    token:string
   role:string
}
export const  postLogin =
async (
    data:{
        
        email:string
        password:string
    }

)=>{

    const res = await request.post<ResponseData>(
        '/api//User/Login',
        data

    );
    return res.data;

}