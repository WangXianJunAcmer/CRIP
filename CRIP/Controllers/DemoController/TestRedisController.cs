using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRIP.Helper;
using StackExchange.Redis;

namespace CRIP.Controllers.DemoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRedisController : ControllerBase
    {
        private readonly IDatabase _redis;
        public TestRedisController(RedisHelper client)
        {
            _redis = client.GetDatabase();
        }
        [HttpGet("test")]
        public string Get()
        {
            // 往Redis里面存入数据
            _redis.StringSet("Name", "hehe");

            // 从Redis里面取数据
            string name = _redis.StringGet("Name");
            return name;
        }
    }



}
