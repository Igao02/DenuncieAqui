﻿using DenuncieAqui.Domain.Repositories;
using DenuncieAqui.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DenuncieAqui.Infrastructure.Repositories;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly ApplicationDbContext _context;

    public InstitutionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Institution?> GetAsync(Guid id) => await _context.Institutions.FindAsync(id);

    public async Task<Institution> AddAsync(Institution institution)
    {
        await _context.AddAsync(institution);

        await _context.SaveChangesAsync();

        return institution;
    }

    public async Task DeleteAsync(Guid id)
    {
        var institution = await GetAsync(id);

        _context.Institutions.Remove(institution!);

        await _context.SaveChangesAsync();
    }

    public async Task<Institution> EditAsync(Institution institution)
    {
        _context.Entry(institution).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return institution;
    }

}
