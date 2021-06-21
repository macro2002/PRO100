using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("API/[controller]/{action}")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public string Current()
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "App_Data/Updates");
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);

                var updates = new List<Update>();
                foreach(var file in files)
                {
                    FileInfo info = new FileInfo(files.Last());
                    if (info.Exists)
                    {
                        updates.Add(new Update
                        {
                            Name = info.Name.Substring(0, info.Name.Length - 4),
                            CreationTime = info.CreationTime
                        });
                    }
                }
                updates = updates.OrderBy(u => u.CreationTime).ToList();
                return updates.Last().Name;
            }
            return "none";
        }

        //[HttpGet]
        //public void GetUpdate()
        //{

        //}
    }
}
