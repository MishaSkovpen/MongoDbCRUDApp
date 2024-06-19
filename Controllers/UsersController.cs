// Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly MongoDbContext _context;

    public UsersController(MongoDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _context.Users.Find(user => true).ToListAsync();
        return Ok(users);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(string id)
    {
        var user = await _context.Users.Find(user => user.Id == id).FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        await _context.Users.InsertOneAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, User updatedUser)
    {
        var user = await _context.Users.Find(user => user.Id == id).FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        updatedUser.Id = user.Id;
        await _context.Users.ReplaceOneAsync(user => user.Id == id, updatedUser);

        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _context.Users.Find(user => user.Id == id).FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        await _context.Users.DeleteOneAsync(user => user.Id == id);

        return NoContent();
    }
}

