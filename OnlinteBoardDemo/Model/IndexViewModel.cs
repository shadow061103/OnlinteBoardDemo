using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlinteBoardDemo.Model
{
    public class IndexViewModel
    {
        [StringLength(20,ErrorMessage ="超過指定長度")]
        [Display(Name ="關鍵字查詢")]
        public string KeyWord { get; set; }
        
    }
}