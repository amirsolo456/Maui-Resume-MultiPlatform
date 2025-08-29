using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Resume.Domain.Models
{
    /// <summary>
    /// اطلاعات تماس شخص
    /// </summary>
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// نوع تماس (مثلاً Email, Phone, LinkedIn)
        /// </summary>
        [Required, MaxLength(50)]
        public string Type { get; set; } = "";

        /// <summary>
        /// مقدار تماس (مثلاً ایمیل یا شماره)
        /// </summary>
        [Required, MaxLength(300)]  
        public string Value { get; set; } = "";

        /// <summary>
        /// شناسه آیتم Navigation مرتبط
        /// </summary>
        public Guid? NavigationItemId { get; set; }

        public NavigationItem? NavigationItem { get; set; }

        /// <summary>
        /// شناسه شخص مرتبط
        /// </summary>
        public Guid? PersonId { get; set; }

        public Person? Person { get; set; }
    }
}

