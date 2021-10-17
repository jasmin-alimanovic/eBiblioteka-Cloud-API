using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eBibliotekaCloud.Models;
using eBibliotekaCloud.Data.Models.DTOs.Korisnik;
using eBibliotekaCloud.Utils;
using eBibliotekaCloud.Services;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using System.IO;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;

namespace eBibliotekaCloud.Controllers
{

    


    [Route("api/users")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IUserService _service;

        public KorisnikController(IUserService service)
        {
            _service = service;
        }

        // GET: api/users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<KorisnikReadDTO>>> GetUsers(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var users = await _service.GetUsersAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int booksSize = await _service.GetUserSizeAsync();
            int numberOfPages = (int)Math.Ceiling(booksSize / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<KorisnikReadDTO>()
            {
                Data = users,
                Count = booksSize,
                Next = next,
                Previous = prev
            };

            return Ok(result);
        }

        // GET: api/users/new-users
        [HttpGet("new-users")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<KorisnikReadDTO>>> GetNewUsers(string sort, string q, int? page_index = 1, int? page_size = 5)
        {
            //get users from db
            var users = await _service.GetNewUsersAsync(sort, q, page_index, page_size);

            //get current uri
            string baseUrl = $"{Request?.Scheme}://{Request?.Host}";

            //variables for next and previous page of pagination
            string prev = null, next = null;
            if (page_index > 1)
            {
                prev = $"{baseUrl}?page_index={page_index - 1}&page_size={page_size}";
            }

            int count = await _service.GetNewUsersCountAsync();
            int numberOfPages = (int)Math.Ceiling(count / (double)page_size);
            if (page_index < numberOfPages) //if page index is smaller then number of pages then we have next page
            {
                next = $"{baseUrl}?page_index={page_index + 1}&page_size={page_size}";
            }

            //wrap users in result object
            var result = new EndpointResult<KorisnikReadDTO>()
            {
                Data = users,
                Count = count,
                Next = next,
                Previous = prev
            };

            return Ok(result);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knjiga>> GetUser(int id)
        {
            var user = await _service.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("test")]
        public ActionResult Test()
        {


            var obj = new
            {
                success = true
            };
            return Ok(obj);
        }


        // GET: api/users/fid/qwlsakfosf1431ad
        [HttpGet("fid/{fid}")]
        public async Task<ActionResult<Knjiga>> GetUserByFId(string fid)
        {
            var user = await _service.GetUserByFirebaseIdAsync(fid);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/users/email/example@email.com
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Knjiga>> GetUserByEmailAsync(string email)
        {
            var user = await _service.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/users/
        [HttpGet("group-by-date")]
        public  ActionResult GetUsersCountByDate(int days = 7)
        {
            try
            {
                var user = _service.GetUsersCountByDate(days);


                return Ok(user);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, KorisnikUpdateDTO korisnik)
        {
            var isUpdated = await _service.UpdateUserAsync(id, korisnik);
            if (!isUpdated)
            {
                return BadRequest();

            }

            return NoContent();
        }

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-user")]
        public async Task<ActionResult<Knjiga>> AddUser(KorisnikCreateDTO korisnikCreateDTO)
        {
            try
            {
                var knjiga = await _service.AddUserAsync(korisnikCreateDTO);
                return CreatedAtAction(nameof(GetUser), new { id = knjiga.Id }, knjiga);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add-user-firebase")]
        public async Task<IActionResult> AddUserToFirebase(FirebaseUser firebaseUser)
        {
            var auth = FirebaseAuth.DefaultInstance;
            try
            {
                var user = await auth.CreateUserAsync(new UserRecordArgs()
                {
                    DisplayName = firebaseUser.Ime + " " + firebaseUser.Prezime,
                    Email = firebaseUser.Email,
                    EmailVerified = false,
                    Password = firebaseUser.Password,
                    Disabled = false,
                });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
