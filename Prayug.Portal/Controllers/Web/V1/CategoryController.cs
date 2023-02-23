﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prayug.Infrastructure;
using Prayug.Infrastructure.Enums;
using Prayug.Infrastructure.Models;
using Prayug.Infrastructure.ResponseFormat;
using Prayug.Infrastructure.SmartTable;
using Prayug.Module.Core.Interfaces.RepositoryInterfaces.Web;
using Prayug.Module.Core.ViewModels.Request;
using Prayug.Module.Core.ViewModels.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prayug.Portal.Controllers.Web.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _category;
        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryVm entity)
        {
            using (ISingleStatusResponse<int> response = new SingleStatusResponse<int>())
            {
                int Status = 0;
                try
                {
                    TokenInfo userdetail = TokenDetail.GetTokenInfo(HttpContext.User);
                    if (entity != null && userdetail != null)
                    {
                        if (entity != null)
                        {
                            Status = await _category.CreateCategory(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Category Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Category already exist";
                            }
                            else
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Failure";
                            }
                        }
                        else
                        {
                            response.Status = ResponseMessageEnum.Failure;
                            response.Message = "Empty Request ";
                        }

                        return Ok(response);
                    }
                    else
                    {
                        response.Status = ResponseMessageEnum.Failure;
                        response.Message = "You are not authorized to perform this operation";
                        return Unauthorized(response);
                    }
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = ex.Message;
                    return StatusCode(500, response);
                }
            }
        }
        [HttpPost("CreateCertifyCategory")]
        public async Task<IActionResult> CreateCertifyCategory([FromBody] CertifyCategoryVm entity)
        {
            using (ISingleStatusResponse<int> response = new SingleStatusResponse<int>())
            {
                int Status = 0;
                try
                {
                    TokenInfo userdetail = TokenDetail.GetTokenInfo(HttpContext.User);
                    if (entity != null && userdetail != null)
                    {
                        if (entity != null)
                        {
                            Status = await _category.CreateCertifyCategory(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Category Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Category already exist";
                            }
                            else
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Failure";
                            }
                        }
                        else
                        {
                            response.Status = ResponseMessageEnum.Failure;
                            response.Message = "Empty Request ";
                        }

                        return Ok(response);
                    }
                    else
                    {
                        response.Status = ResponseMessageEnum.Failure;
                        response.Message = "You are not authorized to perform this operation";
                        return Unauthorized(response);
                    }
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = ex.Message;
                    return StatusCode(500, response);
                }
            }
        }
        [AllowAnonymous]
        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            using (ISingleModelResponse<IEnumerable<CategoryVm>> response = new SingleModelResponse<IEnumerable<CategoryVm>>())
            {
                try
                {
                    IEnumerable<CategoryVm> obj = await _category.GetCategoryList();
                    response.objResponse = obj;
                    response.Status = (obj != null && obj.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Category List";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
        [AllowAnonymous]
        [HttpPost("CertifyCategoryList")]
        public async Task<IActionResult> CertifyCategoryList([FromBody] SmartTableParam<CertifyCategorySearchRequestVm> entity)
        {
            using (ISingleListResponse<IEnumerable<CertifyCategoryVm>> response = new SingleListResponse<IEnumerable<CertifyCategoryVm>>())
            {
                try
                {
                    (IEnumerable<CertifyCategoryVm>, Int64) obj = await _category.GetCertifyCategoryList(entity.paging.pageNo, entity.paging.pageSize, entity.paging.sortName, entity.paging.sortType, entity.Search);
                    response.Status = ResponseMessageEnum.Success;
                    response.Message = (obj.Item2 > 0) ? "Success" : "No data fround";

                    response.pageSize = entity.paging.pageSize;
                    response.TotalRecord = obj.Item2;
                    response.objResponse = obj.Item1;
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
        [AllowAnonymous]
        [HttpGet("GetCategoryCourses")]
        public async Task<IActionResult> GetCategoryCourses()
        {
            using (ISingleModelResponse<IEnumerable<CategoryCourses>> response = new SingleModelResponse<IEnumerable<CategoryCourses>>())
            {
                try
                {
                    IEnumerable<CategoryCourses> obj = await _category.GetCategoryCourses();
                    response.objResponse = obj;
                    response.Status = (obj != null && obj.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Category List";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
        [AllowAnonymous]
        [HttpGet("GetUserTextSearch")]
        public async Task<IActionResult> GetUserTextSearch(string user_search)
        {
            using (ISingleModelResponse<IEnumerable<CategoryCourses>> response = new SingleModelResponse<IEnumerable<CategoryCourses>>())
            {
                try
                {
                    IEnumerable<CategoryCourses> obj = await _category.GetUserTextSearch(user_search);
                    response.objResponse = obj;
                    response.Status = (obj != null && obj.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Category or Course List";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
        [AllowAnonymous]
        [HttpGet("GetCertifyCategoryList")]
        public async Task<IActionResult> GetCertifyCategoryList(int user_id)
        {
            using (ISingleModelResponse<IEnumerable<CertifyCategoryVm>> response = new SingleModelResponse<IEnumerable<CertifyCategoryVm>>())
            {
                try
                {
                    IEnumerable<CertifyCategoryVm> obj = await _category.GetCertifyCategoryList(user_id);
                    response.objResponse = obj;
                    response.Status = (obj != null && obj.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Category List";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
        [AllowAnonymous]
        [HttpGet("GetCertifyCategoryCourses")]
        public async Task<IActionResult> GetCertifyCategoryCourses()
        {
            using (ISingleModelResponse<IEnumerable<CategoryCourses>> response = new SingleModelResponse<IEnumerable<CategoryCourses>>())
            {
                try
                {
                    IEnumerable<CategoryCourses> obj = await _category.GetCertifyCategoryCourses();
                    response.objResponse = obj;
                    response.Status = (obj != null && obj.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Certify Category List";
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.Status = ResponseMessageEnum.Exception;
                    response.Message = "Exception";
                    response.Message = ex.Message;
                    return Ok(response);
                }
            }
        }
    }
}
