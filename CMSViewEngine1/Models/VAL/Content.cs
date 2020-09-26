using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CMSViewEngine1.Models.VAL
{
    public class Content
    {
        string _pageContent;
               
        public int Id { get; set; }
        
        public int PageID { get; set; }
        [ForeignKey("PageID")]
        [ScriptIgnore]
        public MainPage ParentID { get; set; }
        
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string PageContent
        {
            get
            {
                return HttpUtility.HtmlDecode(_pageContent);
            }

            set
            {
                string sanitized = HttpUtility.HtmlEncode(value);
                _pageContent = sanitized;
            }
        }

        public DateTime? AddedDate { get; set; }

       

    }
}