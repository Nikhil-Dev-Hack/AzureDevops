using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ALLMVC.Controllers
{
    public class AllCacheController : Controller
    {
        string key = "IDGKey";
        string obj;
        private readonly IMemoryCache _memoryCache;

        public AllCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_memoryCache.TryGetValue<string>(key, out obj))
            {
                obj = DateTime.Now.ToString();
                _memoryCache.Set<string>(key, obj);
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult GetOrCreatethis()
        {
            //return _memoryCache.GetOrCreate<string>("IDGKey", cacheEntry =>
            //{
            //    //return View(DateTime.Now.ToString());
            //});
            return View();
        }
    }
}
