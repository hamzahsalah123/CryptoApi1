using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{
    private const int Shift = 3;

    [HttpPost("encrypt")]
    public IActionResult Encrypt([FromBody] string text)
    {
        return Ok(Caesar(text, Shift));
    }

    [HttpPost("decrypt")]
    public IActionResult Decrypt([FromBody] string text)
    {
        return Ok(Caesar(text, -Shift));
    }

    private string Caesar(string input, int shift)
    {
        return new string(input.Select(c =>
        {
            if (!char.IsLetter(c)) return c;
            char a = char.IsUpper(c) ? 'A' : 'a';
            return (char)((c - a + shift + 26) % 26 + a);
        }).ToArray());
    }
}
