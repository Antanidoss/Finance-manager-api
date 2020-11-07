﻿using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Persistence.Common.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly EFDbContext _context;

        public ReportRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task AddReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task<Report> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.Id == reportId);
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(int skip, int take)
        {
            return await _context.Reports
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(int skip, int take, Func<Report, bool> func)
        {
            return _context.Reports
                .AsQueryable()
                .Where(func)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public async Task RemoveReportAsync(Report report)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}