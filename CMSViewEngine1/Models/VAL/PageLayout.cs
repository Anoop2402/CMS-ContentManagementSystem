using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSViewEngine1.Models.VAL
{
    public class PageLayout
    {

        string _template;
        string _top;
        string _bottom;

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PageTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Template
        {
            get
            {
                return HttpUtility.HtmlDecode(_template);
            }

            set
            {
                string sanitized = HttpUtility.HtmlEncode(value);
                _template = sanitized;
            }
        }
        [AllowHtml]
        public string Top
        {
            get
            {
                return HttpUtility.HtmlDecode(_top);
            }

            set
            {
                string sanitized = HttpUtility.HtmlEncode(value);
                _top = sanitized;
            }
        }

        [AllowHtml]
        public string Bottom
        {
            get
            {
                return HttpUtility.HtmlDecode(_bottom);
            }

            set
            {
                string sanitized = HttpUtility.HtmlEncode(value);
                _bottom = sanitized;
            }
        }




        public List<Content> Content { get; set; }






    }
}