using DotNet7.BlazorWebApp.WebApi.Features.Blog;
using DotNet7.BlazorWebApp.WebApi.Models.Blog;
using DotNet7.BlazorWebApp.WebApi.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7.BlazorWebApp.WebApi.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_BLog _bL_Blog;

        public BlogController(BL_BLog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetBlog(int pageNo, int pageSize)
        {
            var responseModel = new Result<List<BlogModel>>();
            try
            {
                responseModel = await _bL_Blog.GetBlog(pageNo, pageSize);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel = Result<List<BlogModel>>.FailureResult(ex.ToString());
                return BadRequest(responseModel);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var responseModel = new Result<BlogModel>();
            try
            {
                responseModel = await _bL_Blog.GetBlog(id);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogModel>.FailureResult(ex.ToString());
                return BadRequest(responseModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogModel reqModel)
        {
            var responseModel = new Result<string>();
            try
            {
                responseModel = await _bL_Blog.CreateBlog(reqModel);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel = Result<string>.FailureResult(ex.ToString());
                return BadRequest(responseModel);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogModel reqModel)
        {
            var responseModel = new Result<string>();
            try
            {
                responseModel = await _bL_Blog.UpdateBlog(id, reqModel);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel = Result<string>.FailureResult(ex.ToString());
                return BadRequest(responseModel);   
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var responseModel = new Result<string>();
            try
            {
                responseModel = await _bL_Blog.DeleteBlog(id);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                responseModel = Result<string>.FailureResult(ex.ToString());
                return BadRequest(responseModel);
            }
        }
    } 
}
