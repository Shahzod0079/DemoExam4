using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DemoExam4.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam4.Classes
{
    public class DbConnection : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DocumentReg> DocumentRegs { get; set; }

        public DbConnection()
        {
            try
            {
                Database.EnsureCreated();
                DocumentRegs.Load();
                Statuses.Load();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3307;uid=root;pwd=;database=DemoExam4",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

    } 

}
