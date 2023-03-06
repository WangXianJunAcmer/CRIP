using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRIP.Helper
{
    public class qiniu_imgHelper
    {
        string   AccessKey = "7mvPBtZUC31MF2dtquEr3Jl-g_ZtjQ81n_Q9F4Eb";
        string   SecretKey = "OD2LhIhxdt9A7S0JI2cs7JZeaO-gu_mGIpghcWE6";
        string Bucket = "crip";
        // 上传文件名
        // 本地文件路径
        // 存储空间名
        public string FileUpload(string key, string filePath)
        {
            Console.WriteLine(filePath);
            Mac mac = new Mac(AccessKey, SecretKey);
            // 设置上传策略
            PutPolicy putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            //   putPolicy.DeleteAfterDays = 1;
            // 生成上传token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

            Config config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZONE_CN_North;
/*up-cn-east-2.qiniup.com
机 房 Zone对象
华 东 ZONE_CN_East
华 北 ZONE_CN_North
华 南 ZONE_CN_South
北 美 ZONE_US_North
东南亚 ZONE_AS_Singapore*/
            // 设置 http 或者 https 上传
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result = target.UploadFile(filePath, key, token, null);
            Console.WriteLine("form upload result: " + result.ToString());
            return key;
        }



    }
}

