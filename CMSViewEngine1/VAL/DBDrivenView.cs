using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CMSViewEngine1.Models;
using CMSViewEngine1.Models.VAL;

namespace CMSViewEngine1.VAL
{
    public class DBDrivenView: IView
    {
        
        DBViewEngineContext db = new DBViewEngineContext();
        string _viewName;

        public DBDrivenView(string viewName)
        {
            if(string.IsNullOrEmpty(viewName))
            {
                throw new ArgumentNullException("viewName", new ArgumentException("View name cannot be null!!"));
            }
            _viewName = viewName;
        }




        public void Render(ViewContext viewContext, TextWriter Writer)
        {
            
            MainPage mnp = db.MainPage.Include("Content").Include("Pages").First(f=>f.Name==_viewName);
            
            int num=Convert.ToInt32(mnp.PageType);
            string pghtml=Convert.ToString(mnp.Layout);
            var top = (from c in db.PageLayout
                       where c.Id == num
                       select new { c.Top }).First();

            var a = top.Top;
            
            var bot = (from t in db.PageLayout
                      where t.Id == num
                      select new { t.Bottom }).First();

            var b =bot.Bottom;

            //var title = (from n in db.
            //           where n.Id == num
            //           select new { n. }).First();

            //var a = top.Top;
           
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using (HtmlTextWriter htmlWriter = new HtmlTextWriter(sw))
            {
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
              
                    
                   

                
                foreach (var item in mnp.Content)
                {
                    string er = "Please Add Content To The Page..";
                    var replacements = new Dictionary<string, string> { { "@Top",  "<title>"+mnp.PageTitle.ToString()+"| Chic Infotech</title>"+a }, { "@Content", item.PageContent }, { "@Bottom", b } };
                    var Error = new Dictionary<string, string> { { "@Top", a }, { "@Content", er }, { "@Bottom", b } };
                   if(item.PageContent.Equals(null))
                   {
                       Writer.Write(Error.Aggregate(pghtml, (current, replacement) => current.Replace(replacement.Key, replacement.Value))); 
                   }
                    
                    Writer.Write(replacements.Aggregate(pghtml, (current, replacement) => current.Replace(replacement.Key, replacement.Value)));
              
                }

                
                   

            
                htmlWriter.RenderEndTag();


                //htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);
                //foreach (var item in mnp.Pages)
                //{

                //    Writer.Write(mnp.Layout.Replace("@Content", item.Template));

                //}
                //htmlWriter.RenderEndTag();
    
            }

          //  Writer.Write(mnp.Layout);
          
        }




    }
}