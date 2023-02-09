﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public class TutorController : ControllerBase
    {
        private ITutorRepository _tutorRepository;
        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        [HttpPost]
        [Route("GetCourseList")]
        public async Task<IActionResult> GetCourseList([FromBody] SmartTableParam<CourseSearchRequestVm> entity)
        {
            //var tt = ResponseMessageEnum.Exception.GetDescription();
            using (ISingleListResponse<IEnumerable<CourseListVm>> response = new SingleListResponse<IEnumerable<CourseListVm>>())
            {
                try
                {
                    (IEnumerable<CourseListVm>, Int64) objResult = await _tutorRepository.GetCourseList(entity.paging.pageNo, entity.paging.pageSize, entity.paging.sortName, entity.paging.sortType, entity.Search);
                    response.Status = ResponseMessageEnum.Success;
                    response.Message = (objResult.Item2 > 0) ? "Success" : "No data fround";

                    response.pageSize = entity.paging.pageSize;
                    response.TotalRecord = objResult.Item2;
                    response.objResponse = objResult.Item1;
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
        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseVm entity)
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
                            Status = await _tutorRepository.CreateCourse(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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
        [HttpPut("EditCourse")]
        public async Task<IActionResult> EditCourse([FromBody] CourseVm entity)
        {
            using (ISingleStatusResponse<int> response = new SingleStatusResponse<int>())
            {
                int Status = 0;
                try
                {
                    TokenInfo userdetail = TokenDetail.GetTokenInfo(HttpContext.User);
                    if (entity != null && userdetail != null && entity.course_id > 0)
                    {
                        if (entity != null)
                        {
                            Status = await _tutorRepository.EditCourse(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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
        [HttpDelete("GetCourseDelete")]
        public async Task<IActionResult> GetCourseDelete(int course_id)
        {
            using (ISingleModelResponse<int> response = new SingleModelResponse<int>())
            {
                try
                {
                    int result = await _tutorRepository.GetCourseDelete(course_id);
                    response.objResponse = result;
                    response.Status = (result > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "item";
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
        [HttpPost("CreateCourseStructure")]
        public async Task<IActionResult> CreateCourseStructure([FromBody] CourseStructureVm entity)
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
                            Status = await _tutorRepository.CreateCourseStructure(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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
        [HttpGet("GetCourseStructure")]
        public async Task<IActionResult> GetCourseStructure(int course_id)
        {
            using (ISingleModelResponse<IEnumerable<CourseStructureVm>> response = new SingleModelResponse<IEnumerable<CourseStructureVm>>())
            {
                try
                {
                    IEnumerable<CourseStructureVm> objView = await _tutorRepository.GetCourseStructure(course_id);
                    response.objResponse = objView;
                    response.Status = (objView != null && objView.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Lession Item List";
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
        [HttpPost("CreateCourseSkill")]
        public async Task<IActionResult> CreateCourseSkill([FromBody] CourseSkillVm entity)
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
                            Status = await _tutorRepository.CreateCourseSkill(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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
        [HttpGet("GetCourseSkill")]
        public async Task<IActionResult> GetCourseSkill(int course_id)
        {
            using (ISingleModelResponse<IEnumerable<CourseSkillVm>> response = new SingleModelResponse<IEnumerable<CourseSkillVm>>())
            {
                try
                {
                    IEnumerable<CourseSkillVm> objView = await _tutorRepository.GetCourseSkill(course_id);
                    response.objResponse = objView;
                    response.Status = (objView != null && objView.Count() > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Course skill List";
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
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderVm entity)
        {
            using (ISingleModelResponse<int> response = new SingleModelResponse<int>())
            {
                int id = 0;
                try
                {
                    TokenInfo userdetail = TokenDetail.GetTokenInfo(HttpContext.User);
                    if (entity != null && userdetail != null)
                    {
                        if (entity != null)
                        {
                            id = await _tutorRepository.CreateOrder(entity, userdetail);
                            if (id > 0)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Order Successfully Created";
                                response.objResponse = id;
                            }
                            else
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Failure";
                                response.objResponse = 0;
                            }
                        }
                        else
                        {
                            response.Status = ResponseMessageEnum.Failure;
                            response.Message = "Empty Request ";
                            response.objResponse =0;
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
        [HttpPost]
        [Route("AllUserList")]
        public async Task<IActionResult> AllUserList([FromBody] SmartTableParam<UserSearchRequestVm> entity)
        {
            //var tt = ResponseMessageEnum.Exception.GetDescription();
            using (ISingleListResponse<IEnumerable<UserListVm>> response = new SingleListResponse<IEnumerable<UserListVm>>())
            {
                try
                {
                    (IEnumerable<UserListVm>, Int64) objResult = await _tutorRepository.AllUserList(entity.paging.pageNo, entity.paging.pageSize, entity.paging.sortName, entity.paging.sortType, entity.Search);
                    response.Status = ResponseMessageEnum.Success;
                    response.Message = (objResult.Item2 > 0) ? "Success" : "No data fround";

                    response.pageSize = entity.paging.pageSize;
                    response.TotalRecord = objResult.Item2;
                    response.objResponse = objResult.Item1;
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
        [HttpGet("GetUserActive")]
        public async Task<IActionResult> GetUserActive(int user_id)
        {
            using (ISingleModelResponse<int> response = new SingleModelResponse<int>())
            {
                try
                {
                    int result = await _tutorRepository.GetUserActive(user_id);
                    response.objResponse = result;
                    response.Status = (result > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "User Active";
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
        [HttpDelete("GetUserDelete")]
        public async Task<IActionResult> GetUserDelete(int user_id)
        {
            using (ISingleModelResponse<int> response = new SingleModelResponse<int>())
            {
                try
                {
                    int result = await _tutorRepository.GetUserDelete(user_id);
                    response.objResponse = result;
                    response.Status = (result > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Deleted";
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
        [HttpGet("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail(int user_id)
        {
            using (ISingleModelResponse<UserListVm> response = new SingleModelResponse<UserListVm>())
            {
                try
                {
                    UserListVm objView = await _tutorRepository.GetUserDetail(user_id);
                    response.objResponse = objView;
                    response.Status = (objView != null) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Course";
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
        [HttpGet("UserPermissionAction")]
        public async Task<IActionResult> UserPermissionAction(int user_id)
        {
            using (ISingleModelResponse<int> response = new SingleModelResponse<int>())
            {
                try
                {
                    int result = await _tutorRepository.UserPermissionAction(user_id);
                    response.objResponse = result;
                    response.Status = (result > 0) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "User Action";
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
        [HttpGet("GetCourseOverview")]
        public async Task<IActionResult> GetCourseOverview(int course_id)
        {
            using (ISingleModelResponse<CourseOverviewVm> response = new SingleModelResponse<CourseOverviewVm>())
            {
                try
                {
                    CourseOverviewVm objView = await _tutorRepository.GetCourseOverview(course_id);
                    response.objResponse = objView;
                    response.Status = (objView != null) ? ResponseMessageEnum.Success : ResponseMessageEnum.Failure;
                    response.Message = "Course";
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
        [HttpPost("CreateCourseOverview")]
        public async Task<IActionResult> CreateCourseOverview([FromBody] CourseOverviewVm entity)
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
                            Status = await _tutorRepository.CreateCourseOverview(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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
        [HttpPut("UpdateCourseOverview")]
        public async Task<IActionResult> UpdateCourseOverview([FromBody] CourseOverviewVm entity)
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
                            Status = await _tutorRepository.UpdateCourseOverview(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Updated";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course does not exist";
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
        [HttpPost]
        [Route("GetCourseOverviewList")]
        public async Task<IActionResult> GetCourseOverviewList([FromBody] SmartTableParam<CourseSearchRequestVm> entity)
        {
            //var tt = ResponseMessageEnum.Exception.GetDescription();
            using (ISingleListResponse<IEnumerable<CourseListVm>> response = new SingleListResponse<IEnumerable<CourseListVm>>())
            {
                try
                {
                    (IEnumerable<CourseListVm>, Int64) objResult = await _tutorRepository.GetCourseOverviewList(entity.paging.pageNo, entity.paging.pageSize, entity.paging.sortName, entity.paging.sortType, entity.Search);
                    response.Status = ResponseMessageEnum.Success;
                    response.Message = (objResult.Item2 > 0) ? "Success" : "No data fround";

                    response.pageSize = entity.paging.pageSize;
                    response.TotalRecord = objResult.Item2;
                    response.objResponse = objResult.Item1;
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
        [HttpPost]
        [Route("GetCertifyCourseList")]
        public async Task<IActionResult> GetCertifyCourseList([FromBody] SmartTableParam<CertifyCourseSearchVm> entity)
        {
            //var tt = ResponseMessageEnum.Exception.GetDescription();
            using (ISingleListResponse<IEnumerable<CourseListVm>> response = new SingleListResponse<IEnumerable<CourseListVm>>())
            {
                try
                {
                    (IEnumerable<CourseListVm>, Int64) objResult = await _tutorRepository.GetCertifyCourseList(entity.paging.pageNo, entity.paging.pageSize, entity.paging.sortName, entity.paging.sortType, entity.Search);
                    response.Status = ResponseMessageEnum.Success;
                    response.Message = (objResult.Item2 > 0) ? "Success" : "No data fround";

                    response.pageSize = entity.paging.pageSize;
                    response.TotalRecord = objResult.Item2;
                    response.objResponse = objResult.Item1;
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
        [HttpPost("CreateCertifyCourse")]
        public async Task<IActionResult> CreateCertifyCourse([FromBody] CertifyCourseVm entity)
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
                            Status = await _tutorRepository.CreateCertifyCourse(entity, userdetail);
                            if (Status == 1)
                            {
                                response.Status = ResponseMessageEnum.Success;
                                response.Message = "Course Successfully Created";
                            }
                            else if (Status == 2)
                            {
                                response.Status = ResponseMessageEnum.Failure;
                                response.Message = "Course already exist";
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

    }

}
