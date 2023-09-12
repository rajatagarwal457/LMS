using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/items")]
[ApiController]
public class items: ControllerBase
{
    private readonly LmsContext _db;

    public items(LmsContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<ActionResult> item(String eid)
    {
        string q = $"  select eid.issue_id, im.item_description, im.item_make, im.item_category, im.item_valuation from employee_issue_details as eid, item_master as im where eid.item_id = im.item_id and eid.employee_id = {eid};";
        var res = _db.Database.SqlQueryRaw<(string, string, string, string, int)>(q);
        
        if (res.Count() == 0)
        {
            return Unauthorized();
        }
        else
        {
            return Ok(res);
        }

    }
}