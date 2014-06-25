using System;

namespace GoF_ShowCase.Builder.PageBuilder {
    public class PageBuilder : IPageBuilder {
        private readonly Page page = new Page();

        public void BuildHeader(HeaderData header) {
            page.AddHeader(header);
        }

        public void BuildMenu(MenuItems menuItems) {
            page.SetMenuItems(menuItems);
        }

        public void BuildPost(PostData post) {
            page.AddPost(post);
        }

        public void BuildFooter(FooterData footer) {
            page.AddFooter(footer);
        }

        public Page GetResult() {
            return page;
        }
    }

    public class PrintPageBuilder : IPageBuilder {
        private readonly Page page = new Page();

        private PostData PreparePostToPrinter(PostData post) {
            /* SKIPPED */
            throw new NotImplementedException();
        }

        public void BuildHeader(HeaderData header) {}

        public void BuildMenu(MenuItems menuItems) {}

        public void BuildPost(PostData post) {
            var postToPrint = PreparePostToPrinter(post);
            page.AddPost(postToPrint);
        }

        public void BuildFooter(FooterData footer) {}

        public Page GetResult() {
            return page;
        }
    }
}