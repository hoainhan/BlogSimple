using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;
using BlogSimple.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace BlogSimple.Repository.UnitOfWork
{
    public sealed class UnitOfWork:IUnitOfWork
    {
        private BlogSimpleContext _context;

        public UnitOfWork(BlogSimpleContext context)
        {
            _context = context;
        }
        //use transaction for data integrity
        public void Commit()
        {
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }

}
