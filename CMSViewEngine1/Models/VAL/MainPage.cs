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
    public class MainPage
    {
        string _layout;

        [Key]
        public int Id { get; set; }

           
        [Required]
        [RegularExpression("^[a-z]+(-[a-z]+)*$", ErrorMessage = "Page Name cannot contain Capital Letters and can use only Hyphen(-) as a special character ")]
        public string Name { get; set; }
        
        
        [Required]
        [RegularExpression("^(?!.*_)[a-zA-Z!@#%$&()\\-`.+,\"']+(-[a-zA-Z]+)*$", ErrorMessage = "Page Title cannot contain UnderScore(_) ")]
        public string PageTitle { get; set; }

        public int PageType { get; set; }
        [ForeignKey("PageType")]
        [ScriptIgnore]
        public PageLayout PageParent { get; set; }



        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Layout
        {
            get
            {
                return HttpUtility.HtmlDecode(_layout);
            }

            set
            {
                string sanitized = HttpUtility.HtmlEncode(value);
                _layout = sanitized;
            }
        }

        public List<PageLayout> Pages { get; set; }
        public List<Content> Content { get; set; }
    }
}