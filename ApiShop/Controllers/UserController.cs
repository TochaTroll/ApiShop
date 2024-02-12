using ApiShop.Context;
using ApiShop.Dto;
using ApiShop.Helper;
using ApiShop.Interfaces;
using ApiShop.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ShopContext _context;

        public UserController(ShopContext context, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUsers()
        {
            var user = _mapper.Map<List<UserDto>>( await _userRepository.GetUsers());
            if(!ModelState.IsValid)           
                return BadRequest(ModelState);           
            return Ok(user);          
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = _mapper.Map<UserDto>(await _userRepository.GetUser(userId));     
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("role/{userRole}")]
        [ProducesResponseType(200, Type=typeof(UserDto))]
        public async Task<IActionResult> GetUsersByRole(string userRole)
        {
            var user = _mapper.Map<List<UserDto>>(await _userRepository.GetUsersByRole(userRole));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser(UserRegistrationDto userDto)
        {
            if (userDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var user = UserConverter.ConverterUser(_context,userDto);

            if (!await _userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);              
            }
            return Ok("Add user");
        }
    }
}
