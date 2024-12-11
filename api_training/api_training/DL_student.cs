using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using api_training.Controllers;

namespace api_training
{
    public class DL_student
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        private APIResponse res;

        public object Ind { get; private set; }

        internal async Task<APIResponse> FillddlAsync(int Ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {
                    ds = new DataSet();
                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", Ind);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    await Task.Run(() =>
                    {
                        
                        da.Dispose();
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Record not found";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;
        }
        internal async Task<APIResponse> DistrictddlAsync(int Ind, int stateid)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {
                    ds = new DataSet();
                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", Ind);
                    cmd.Parameters.AddWithValue("@StateId", stateid);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    await Task.Run(() =>
                    {

                        da.Dispose();
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Record not found";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;
        }
        internal async Task<APIResponse> BindgriddAsync(int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {
                    ds = new DataSet();
                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    await Task.Run(() =>
                    {

                        da.Dispose();
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Record not found";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;
        }

        internal async Task<APIResponse> MenulistAsync(PL_student plobj, int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {

                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    cmd.Parameters.AddWithValue("@typeofuser", plobj.typeofuser);
                    cmd.Parameters.AddWithValue("@fname", plobj.fname);
                    da = new SqlDataAdapter(cmd);
                    await Task.Run(() =>
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();
                        if (ds != null)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Not Right To Access Any System";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;

        }

        internal async Task<APIResponse> DeleteAsync(PL_student plobj, int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {

                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    cmd.Parameters.AddWithValue("@id", plobj.id);
                    da = new SqlDataAdapter(cmd);
                    await Task.Run(() =>
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();
                        if (ds != null)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Not Right To Access Any System";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;
        }
        internal async Task<APIResponse> Update(PL_student plobj, int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {

                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    cmd.Parameters.AddWithValue("@id", plobj.id);
                    cmd.Parameters.AddWithValue("@fname", plobj.fname);
                    cmd.Parameters.AddWithValue("@mob", plobj.mob);
                    // plobj.calender;
                    DateTime dt = DateTime.Parse(plobj.calender);
                    cmd.Parameters.AddWithValue("@calender", dt);
                    da = new SqlDataAdapter(cmd);
               
                    //cmd.Parameters.AddWithValue("@gen", plobj.gen);
                    //cmd.Parameters.AddWithValue("@cat", plobj.cat);
                    //cmd.Parameters.AddWithValue("@Department", plobj.Department);
                    await Task.Run(() =>
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();
                        if (ds != null)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Not Right To Access Any System";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;

        }

        internal async Task<APIResponse> LoginDetail(PL_student plobj, int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {
                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    cmd.Parameters.AddWithValue("@fname", plobj.fname);
                    cmd.Parameters.AddWithValue("@pswd", plobj.pswd);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    da.Dispose();
                    await Task.Run(() =>
                    {
                        
                        if (ds != null)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Not Right To Access Any System";
                            res.data = null;
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return res;
        }

        internal async Task<APIResponse> SavedetailsAsync(PL_student plobj, int ind)
        {
            res = new APIResponse();
            try
            {
                using (con = new SqlConnection(CommonConnCls.connection()))
                {
                    
                    cmd = new SqlCommand("sp_student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ind", ind);
                    cmd.Parameters.AddWithValue("@fname", plobj.fname);
                    cmd.Parameters.AddWithValue("@mob", plobj.mob);
                    cmd.Parameters.AddWithValue("@calender", plobj.calender);
                    cmd.Parameters.AddWithValue("@gen", plobj.gen);
                    cmd.Parameters.AddWithValue("@cat", plobj.cat);
                    cmd.Parameters.AddWithValue("@Department", plobj.Department);
                    cmd.Parameters.AddWithValue("@pswd", plobj.pswd);
                    cmd.Parameters.AddWithValue("@conpswd", plobj.conpswd);
                    cmd.Parameters.AddWithValue("@districtId", plobj.districtId);
                    cmd.Parameters.AddWithValue("@StateId", plobj.StateId);
                    da = new SqlDataAdapter(cmd);
                    await Task.Run(() =>
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();
                        if (ds != null)
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.OK);
                            res.msg = "Succes";
                            res.data = ds;
                        }
                        else
                        {
                            res.successcode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            res.msg = "Not Right To Access Any System";
                            res.data = null;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                res.successcode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                res.msg = ex.Message;
                res.data = null;
            }
            return res;

        }
    }
}