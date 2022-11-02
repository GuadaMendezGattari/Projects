using System;
using Microsoft.EntityFrameworkCore;
using Comentarios.Models;

namespace Comentarios.Data
{
    public class ComentarioDbContext : DbContext
    {
        public DbSet<Comentario> Comentario { get; set; }
        public ComentarioDbContext(DbContextOptions<ComentarioDbContext> options) : base(options)
        {
        }
    }
}

