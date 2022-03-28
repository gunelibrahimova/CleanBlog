using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogLanguageServices
    {
        private readonly AppDbContext _context;

        public BlogLanguageServices(AppDbContext context)
        {
            _context = context;
        }
        public List<BlogLanguage> GetAllBlogs()
        {
            var blogs = _context.BlogLanguages.Include(x=>x.Blog).Where(x => x.LangCode == "AZ").ToList();

            return blogs;
        }

        public BlogLanguage GetBlogById(int? id, string langCode)
        {
            if(langCode == null)
            {
                langCode = "RU";
            }
           
            var blog = _context.BlogLanguages.Include(x=>x.Blog).FirstOrDefault(x=>x.BlogId == id && x.LangCode == langCode);

            if (blog == null)
            {
                return null;
            }

            return blog;
        }

    }
}
