using ALLMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALLMVC.ViewComponentsFolder
{
    public class SocialLinksViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SocialLinksViewComponent(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _context.socialIcons;
            return await Task.FromResult((IViewComponentResult)View("SocialLinks", models));
        }

    }
}
