using Microsoft.AspNetCore.Mvc;
using rest_api_test.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace rest_api_test.Controllers
{
    [Route("hihi")]
    [ApiController]
    public class LANGUAGE_INFOController : ControllerBase
    {
        //private readonly LANGUAGE_INFOContext _context;
        private static List<LANGUAGE_INFO> _context;
        public LANGUAGE_INFOController()
        {
            //_context = context;
            List<LANGUAGE_INFO> list = new List<LANGUAGE_INFO>();
            LANGUAGE_INFO model;

            for (int i = 0; i < 10; i++)
            {
                model = new LANGUAGE_INFO();
                model.LANGUAGE_CODE = $"test{(i + 1)}";
                model.LANGUAGE_VALUE1 = $"test{(i + 1)}";
                model.LANGUAGE_VALUE2 = $"test{(i + 1)}";
                model.LANGUAGE_VALUE3 = $"test{(i + 1)}";
                list.Add(model);
            }
            _context = list;
        }

        [HttpGet]
        public IEnumerable<LANGUAGE_INFO> Get()
        {
            return _context.Select(Idx => Idx)
                .Where(p => p.LANGUAGE_CODE.Contains("1")).ToArray();
        }

        [Route("Test")]
        [HttpGet]
        public IList getGenericTest()
        {
            //return _context.Select(Idx => Idx).Where(p => p.LANGUAGE_CODE.Contains("1")).ToArray();
            return _context;
        }



    }
}
