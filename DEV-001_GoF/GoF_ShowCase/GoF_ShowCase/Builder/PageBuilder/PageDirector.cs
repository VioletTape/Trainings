using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Builder.PageBuilder {
    public class PageDirector {
        private readonly IPageBuilder builder;

        private HeaderData GetHeader(int pageId) {
            /* SKIPPED */
            throw new NotImplementedException();
        }

        private MenuItems GetMenuItems(int pageId) {
            /* SKIPPED */
            throw new NotImplementedException();
        }

        private IEnumerable<PostData> GetPosts(int pageId) {
            /* SKIPPED */
            throw new NotImplementedException();
        }

        private FooterData GetFooter(int pageId) {
            /* SKIPPED */
            throw new NotImplementedException();
        }

        public PageDirector(IPageBuilder builder) {
            this.builder = builder;
        }

        public void BuildPage(int pageId) {
            builder.BuildHeader(GetHeader(pageId));
            builder.BuildMenu(GetMenuItems(pageId));

            foreach (var post in GetPosts(pageId)) {
                builder.BuildPost(post);
            }

            builder.BuildFooter(GetFooter(pageId));
            
        }
    }
}