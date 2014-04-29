﻿using System.Linq;

using BetterCms.Core.Mvc.Commands;
using BetterCms.Module.Blog.Services;
using BetterCms.Module.Blog.ViewModels.Filter;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Grids.Extensions;

namespace BetterCms.Module.Blog.Commands.ExportBlogPostsCommand
{
    public class ExportBlogPostsCommand : CommandBase, ICommand<BlogsFilter, string>
    {
        private readonly IBlogMLExportService exportService;
        
        private readonly IBlogService blogService;

        public ExportBlogPostsCommand(IBlogMLExportService exportService, IBlogService blogService)
        {
            this.exportService = exportService;
            this.blogService = blogService;
        }

        public string Execute(BlogsFilter request)
        {
            var query = blogService.GetFilteredBlogPostsQuery(request, true);
            var blogPosts = query.AddOrder(request).List();

            var xml = exportService.ExportBlogPosts(blogPosts.ToList());

            return xml;
        }
    }
}