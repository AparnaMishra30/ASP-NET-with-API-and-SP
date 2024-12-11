using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace api_training.Controllers
{
    public class studentController : ApiController
    {
        private APIResponse res;
        DL_student objdl = new DL_student();
                   
        [HttpGet] 
        public async Task<IHttpActionResult> Deptdrop(int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                res = await Task.Run(() => objdl.FillddlAsync(Ind));
                return Content(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> Districtdrop(int Ind = 0, int stateid =0)
        {
            res = new APIResponse();
            try
            {
                res = await Task.Run(() => objdl.DistrictddlAsync(Ind, stateid));
                return Content(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }
        }
        [HttpGet]
        public async Task<IHttpActionResult> Bindgrid(int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                res = await Task.Run(() => objdl.BindgriddAsync(Ind));
                return Content(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> Menulist(PL_student plobj, int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                DL_student dlobj = new DL_student();
                res = await Task.Run(() => dlobj.MenulistAsync(plobj, Ind));
                return Content(HttpStatusCode.OK, res);
            }

            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Savedetail(PL_student plobj, int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                DL_student dlobj = new DL_student();
                res = await Task.Run(() => dlobj.SavedetailsAsync(plobj,Ind));
                return Content(HttpStatusCode.OK, res);
            }

            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Logindetails(PL_student plobj,int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                res = await Task.Run(() => objdl.LoginDetail(plobj,Ind)); ;
                return Content(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(PL_student plobj, int Ind = 0)
        {
            res = new APIResponse();
            try
            {
                res = await Task.Run(() => objdl.Update(plobj, Ind)); ;
                return Content(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message.ToString();
                return Content(HttpStatusCode.InternalServerError, res);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(PL_student plobj, int Ind = 0)
        {
            res = new APIResponse();
                res = await Task.Run(() => objdl.DeleteAsync(plobj, Ind)); ;
                return Content(HttpStatusCode.OK, res);
        }
    }
}
