using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserActivityLog.Data;
using UserActivityLog.Models;

namespace UserActivityLog.Controllers
{
    public class UserLogsController : Controller
    {
        private readonly UserActivityLogContext _context;

        public UserLogsController(UserActivityLogContext context)
        {
            _context = context;
        }

        // GET: UserLogs
        public async Task<IActionResult> Index()
        {
            var userLog = _context.UserLog.OrderByDescending(log => log.login_date).ToList();
            return View(userLog);
        }

        // GET: UserLogs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLog
                .FirstOrDefaultAsync(m => m.ulogo_id == id);
            if (userLog == null)
            {
                return NotFound();
            }

            return View(userLog);
        }

        // GET: UserLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ulogo_id,user_id,user_name,login_date,login_time,ip_address,page_name,controller,http_verb")] UserLog userLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLog);
        }

        // GET: UserLogs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLog.FindAsync(id);
            if (userLog == null)
            {
                return NotFound();
            }
            return View(userLog);
        }

        // POST: UserLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ulogo_id,user_id,user_name,login_date,login_time,ip_address,page_name,controller,http_verb")] UserLog userLog)
        {
            if (id != userLog.ulogo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLogExists(userLog.ulogo_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userLog);
        }

        // GET: UserLogs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLog = await _context.UserLog
                .FirstOrDefaultAsync(m => m.ulogo_id == id);
            if (userLog == null)
            {
                return NotFound();
            }

            return View(userLog);
        }

        // POST: UserLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userLog = await _context.UserLog.FindAsync(id);
            _context.UserLog.Remove(userLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLogExists(long id)
        {
            return _context.UserLog.Any(e => e.ulogo_id == id);
        }
    }
}
