﻿using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogServices
    {
        private readonly AppDbContext _context;

        public BlogServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Blog> GetAll()
        {
            var blog = _context.Blogs.ToList();
            return blog;
        }
    }
}
