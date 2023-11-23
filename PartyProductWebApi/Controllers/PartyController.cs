using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyProductWebApi.DTOs;
using PartyProductWebApi.Models;

namespace PartyProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        public PartyProductWebApiContext _context { get; }
        public IMapper _mapper { get; }

        public PartyController(PartyProductWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartyDTO>>> Get()
        {
            return Ok(await _context.Parties.ToListAsync());
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<PartyDTO>> Get(int Id)
        {

            var party = await _context.Parties.FirstOrDefaultAsync(x => x.Id == Id);
            var partyDTO = _mapper.Map<PartyDTO>(party);
            return partyDTO;

        }

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] PartyCreationDTO partyCreationDTO)
        //{


        //    return NoContent();
        //}

    }
}
