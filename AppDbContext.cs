using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace chatBotUI
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChatHistory> ChatHistory {get; set;}

        public DbSet<Task> Tasks {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}